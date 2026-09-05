using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Alkonof_Backend.Infrastructure.Consumers;

public class ResevedConsumer(ILogger<ResevedConsumer> logger, IApplicationDbContext context) : IConsumer<ResevedHourEvent>
{
    public async Task Consume(ConsumeContext<ResevedHourEvent> consumeContext)
    {
        var responsible = await context.User
            .Include(u=>u.TimeTables)
            .FirstOrDefaultAsync(x => x.Id == consumeContext.Message.ResponsibleId);

        if(responsible == null || responsible.TimeTables == null)
        {
            logger.LogError("Responsible with ID {ResponsibleId} not found.", consumeContext.Message.ResponsibleId);
            return;
        }

        foreach (var timetable in responsible.TimeTables)
        {
            if (timetable.Hour == consumeContext.Message.ResevedHour)
            {
                timetable.Reserve();
                break;
            }
        }
        await context.SaveChangesAsync(consumeContext.CancellationToken);
    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Alkonof_Backend.Infrastructure.Consumers;

public class UnResevedConsumer(ILogger<UnResevedConsumer> logger, IApplicationDbContext context) : IConsumer<UnResevedHourEvent>
{
    public async Task Consume(ConsumeContext<UnResevedHourEvent> consumeContext)
    {
        var responsible = await context.User
            .Include(u => u.TimeTables)
            .FirstOrDefaultAsync(x => x.Id == consumeContext.Message.ResponsibleId);

        if (responsible == null || responsible.TimeTables == null)
        {
            logger.LogError("Responsible with ID {ResponsibleId} not found.", consumeContext.Message.ResponsibleId);
            return;
        }

        foreach (var timetable in responsible.TimeTables)
        {
            if (timetable.Hour == consumeContext.Message.UnResevedHour)
            {
                timetable.UnReserve();
                break;
            }
        }
        await context.SaveChangesAsync(consumeContext.CancellationToken);
    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Exceptions;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Alkonof_Backend.Infrastructure.Consumers;

public class ConfirmeBookingConsumer(ILogger<DelayBookingConsumer> logger, IApplicationDbContext context) : IConsumer<CustomerAnswerAssignedEvent>
{
    public async Task Consume(ConsumeContext<CustomerAnswerAssignedEvent> consumeContext)
    {
        if (consumeContext.Message.Decision == Decision.Approved)
        {
            var booking = await context.Booking
                .FirstOrDefaultAsync(b => b.Id == consumeContext.Message.BookingId);

            if (booking is null)
            {
                throw new NotFoundException(nameof(Booking), consumeContext.Message.BookingId.ToString());
            }

            booking.ConfirmeBookingStatus();

            booking.ResponsiblePendingAnswer();
            booking.CustomerNoneAnswer();

            await context.SaveChangesAsync(consumeContext.CancellationToken);

            logger.LogInformation("[Customer Delayed] - Delayed booking {BookingId}", consumeContext.Message.BookingId);
        }
    }
}

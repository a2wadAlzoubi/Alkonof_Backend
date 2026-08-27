using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Exceptions;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Alkonof_Backend.Infrastructure.Consumers;

public class CancelBookingConsumer(ILogger<CancelBookingConsumer> logger, IApplicationDbContext context) : IConsumer<CustomerAnswerAssignedEvent>
{
    public async Task Consume(ConsumeContext<CustomerAnswerAssignedEvent> consumeContext)
    {
        if (consumeContext.Message.Decision == Decision.Rejected)
        {
            var booking = await context.Booking
                .FirstOrDefaultAsync(b => b.Id == consumeContext.Message.BookingId);

            if (booking is null)
            {
                throw new NotFoundException(nameof(Booking), consumeContext.Message.BookingId.ToString());
            }

            booking.CancellBooking();

            await context.SaveChangesAsync(consumeContext.CancellationToken);

            logger.LogInformation("[Customer Rejected] - Cancelled booking {BookingId}", consumeContext.Message.BookingId);
        }
    }
}

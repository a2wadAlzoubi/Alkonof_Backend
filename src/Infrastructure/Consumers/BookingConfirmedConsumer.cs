using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Alkonof_Backend.Infrastructure.Consumers;

public class BookingConfirmedConsumer(ILogger<BookingConfirmedConsumer> logger) : IConsumer<BookingConfirmedEvent>
{
    public Task Consume(ConsumeContext<BookingConfirmedEvent> context)
    {
        logger.LogInformation("Booking confirmed for booking {BookingId}", context.Message.BookingId);
        return Task.CompletedTask;
    }
}

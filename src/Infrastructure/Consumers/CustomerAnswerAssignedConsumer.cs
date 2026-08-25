using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Alkonof_Backend.Infrastructure.Consumers;

public class CustomerAnswerAssignedConsumer(ILogger<CustomerAnswerAssignedConsumer> logger) : IConsumer<CustomerAnswerAssignedEvent>
{
    public Task Consume(ConsumeContext<CustomerAnswerAssignedEvent> context)
    {
        logger.LogInformation("Customer answer assigned for booking {BookingId}", context.Message.BookingId);
        return Task.CompletedTask;
    }
}

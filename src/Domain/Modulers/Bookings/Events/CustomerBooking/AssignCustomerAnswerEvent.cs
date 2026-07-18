using Alkonof_Backend.Domain.Entities.Bookings.Enum;

namespace Alkonof_Backend.Domain.Modulers.Bookings.Events.CustomerBooking;

public class AssignCustomerAnswerEvent : BaseEvent
{
    public AssignCustomerAnswerEvent(Guid bookingId, Guid customerId, Decision customerAnswer)
    {
        BookingId = bookingId;
        CustomerId = customerId;
        CustomerAnswer = customerAnswer;
    }

    public Guid BookingId { get; set; }
    public Guid CustomerId { get; set; }
    public Decision CustomerAnswer { get; set; }
}

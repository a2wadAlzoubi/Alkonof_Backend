namespace Alkonof_Backend.Domain.Modulers.Bookings.Events.BookingStatusWorkflow;

public class InReviewResponsibleBookingEvent : BaseEvent
{
    public InReviewResponsibleBookingEvent(Guid bookingId, Guid responsibleId)
    {
        BookingId = bookingId;
        ResponsibleId = responsibleId;
    }

    public Guid BookingId { get; set; }
    public Guid ResponsibleId { get; set; }
}

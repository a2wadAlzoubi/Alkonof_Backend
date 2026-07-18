using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.Bookings.Events.BookingStatusWorkflow;

public class ConfirmBookingEvent : BaseEvent
{
    public ConfirmBookingEvent(Guid bookingId, Guid customerId, Guid responsibleId)
    {
        BookingId = bookingId;
        CustomerId = customerId;
        ResponsibleId = responsibleId;
    }

    public Guid BookingId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ResponsibleId { get; set; }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.Bookings.Events.BookingStatusWorkflow;

public class CreateBookingEvent : BaseEvent
{
    public CreateBookingEvent(Guid bookingId, Guid customerId, Guid responsibleId, DateTimeOffset expiredAt)
    {
        BookingId = bookingId;
        CustomerId = customerId;
        ResponsibleId = responsibleId;
        ExpiredAt = expiredAt;
    }

    public Guid BookingId { get; set; }
    public Guid CustomerId{ get; set; }
    public Guid ResponsibleId{ get; set; }
    public DateTimeOffset ExpiredAt { get; set; }
}

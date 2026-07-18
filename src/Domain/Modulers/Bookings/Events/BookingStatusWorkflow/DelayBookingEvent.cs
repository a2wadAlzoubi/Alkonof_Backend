using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.Bookings.Events.BookingStatusWorkflow;

public class DelayBookingEvent : BaseEvent
{
    public DelayBookingEvent(Guid bookingId)
    {
        BookingId = bookingId;
    }

    public Guid BookingId { get; set; }

}

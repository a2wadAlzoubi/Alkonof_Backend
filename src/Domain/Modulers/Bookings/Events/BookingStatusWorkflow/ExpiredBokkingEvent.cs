using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.Bookings.Events.BookingStatusWorkflow;

public class ExpiredBookingEvent : BaseEvent
{
    public ExpiredBookingEvent(Guid bookingId)
    {
        BookingId = bookingId;
    }

    public Guid BookingId { get; set; }
}

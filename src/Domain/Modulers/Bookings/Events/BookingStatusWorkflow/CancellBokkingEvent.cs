using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.Bookings.Events.BookingStatusWorkflow;

public class CancellBookingEvent : BaseEvent
{
    public CancellBookingEvent(Guid bookingId)
    {
        BookingId = bookingId;
    }

    public Guid BookingId { get; set; }
}

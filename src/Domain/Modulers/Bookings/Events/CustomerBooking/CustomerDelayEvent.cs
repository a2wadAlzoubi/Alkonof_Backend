using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.Bookings.Events.CustomerBooking;

public class CustomerDelayEvent : BaseEvent
{
    public CustomerDelayEvent(Guid bookingId, Guid customerId)
    {
        BookingId = bookingId;
        CustomerId = customerId;
    }

    public Guid BookingId { get; set; }
    public Guid CustomerId { get; set; }
}

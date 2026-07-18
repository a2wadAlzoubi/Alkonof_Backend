using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.Bookings.Events.OrderBooking;

public class CreateOrderBookingEvent : BaseEvent
{
    public CreateOrderBookingEvent(Guid orderbookingId, Guid customerId)
    {
        OrderBookingId = orderbookingId;
        CustomerId = customerId;
    }

    public Guid OrderBookingId { get; set; }
    public Guid CustomerId { get; set; }
}

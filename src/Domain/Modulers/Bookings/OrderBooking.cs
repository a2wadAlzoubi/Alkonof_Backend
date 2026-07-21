using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Modulers.Bookings.Events.OrderBooking;

namespace Alkonof_Backend.Domain.Entities.Bookings;

public class OrderBooking : BaseAuditableEntity
{
    private OrderBooking()
    {
        
    }
    private OrderBooking(Guid id ,Guid customerId, Guid serviceId)
    {
        Id = id;
        CustomerId = customerId;
        ServiceId = serviceId;
    }

    public User? Customer { get; private set; }
    public Guid CustomerId { get; private set; }
    public Service? Service { get; private set; }
    public Guid ServiceId { get; private set; }

    public static OrderBooking CreateOrderBooking(Guid customerId, Guid bookingTypeId)
    {
        var orderBooking = new OrderBooking(Guid.NewGuid(),customerId, bookingTypeId);
        orderBooking.AddDomainEvent(new CreateOrderBookingEvent(orderBooking.Id, customerId));
        return orderBooking;
    }
    public void UpdateOrderBooking(Guid customerId, Guid serviceId)
    {
        CustomerId = customerId;
        ServiceId = serviceId;
    }

}

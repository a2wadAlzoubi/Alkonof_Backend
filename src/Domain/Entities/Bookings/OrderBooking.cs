using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Domain.Entities.Bookings;

public class OrderBooking : BaseAuditableEntity
{
    private OrderBooking()
    {
        
    }
    private OrderBooking(Guid id ,Guid customerId, Guid bookingTypeId)
    {
        Id = id;
        CustomerId = customerId;
        BookingTypeId = bookingTypeId;
    }

    public User? Customer { get; private set; }
    public Guid CustomerId { get; private set; }
    public BookingType? BookingType { get; private set; }
    public Guid BookingTypeId { get; private set; }
}

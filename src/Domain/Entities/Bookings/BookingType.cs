using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Bookings;

public class BookingType : BaseAuditableEntity
{
    private BookingType()
    {
        
    }
    private BookingType(Guid id , string serviceName , string description)
    {
        Id = id;
        ServiceName = serviceName;
        Description = description;
    }

    public string ServiceName { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    // Relations
    public ICollection<OrderBooking> OrderBookings { get; private set; } = new List<OrderBooking>();


}

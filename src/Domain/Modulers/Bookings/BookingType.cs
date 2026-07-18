using Alkonof_Backend.Domain.Modulers.Bookings.Events.OrderBooking;

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

    public static BookingType CreateBookingType(string serviceName, string description)
    {
        return new BookingType(Guid.NewGuid(), serviceName, description);
        
    }
    public void UpdateBookingType(string serviceName, string description)
    {
        ServiceName = serviceName;
        Description = description;
    }


}

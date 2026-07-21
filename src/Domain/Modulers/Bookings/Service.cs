using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Modulers.Bookings.Events.OrderBooking;

namespace Alkonof_Backend.Domain.Entities.Bookings;

public class Service : BaseAuditableEntity
{

    private Service()
    {
        
    }
    private Service(Guid id , string serviceName , string description , ServiceType type)
    {
        Id = id;
        ServiceName = serviceName;
        Description = description;
        ServiceType= type;
    }

    public string ServiceName { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public ServiceType ServiceType { get; private set; } 
    // Relations
    public ICollection<OrderBooking> OrderBookings { get; private set; } = new List<OrderBooking>();

    public static Service Create(string serviceName, string description, ServiceType type)
    {
        return new Service(Guid.NewGuid(), serviceName, description , type);
        
    }
    public void Update(string serviceName, string description, ServiceType type)
    {
        ServiceName = serviceName;
        Description = description;
        ServiceType = type;
    }


}

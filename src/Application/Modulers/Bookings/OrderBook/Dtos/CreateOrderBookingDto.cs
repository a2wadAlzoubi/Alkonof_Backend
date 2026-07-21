namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Dtos;

public class CreateOrderBookingDto
{
    public Guid CustomerId { get; set; }
    public Guid BookingTypeId { get; set; }
    public string? CustomerName { get; set; }
    public string? BookingTypeServiceName { get; set; }
}

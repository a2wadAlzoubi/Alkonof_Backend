namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Dtos;

public class OrderBookingDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BookingTypeId { get; set; }
    public string? CustomerName { get; set; }
    public string? BookingTypeServiceName { get; set; }
}

using Alkonof_Backend.Domain.Entities.Bookings.Enum;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;

public class CreateBookingDto
{
    public string Title { get; set; } = string.Empty;
    public DateTimeOffset ExpiredAt { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ResponsibleId { get; set; }
    public Decision CustomerAnswer { get; set; }
    public Decision ResponsibleAnswer { get; set; }
    public BookingStatus Status { get; set; }
    public Guid? ContractId { get; set; }
    public string? CustomerName { get; set; }
    public string? ResponsibleName { get; set; }
}

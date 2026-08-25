using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.UpdateBookingResponsibleId;

public sealed record UpdateBookingResponsibleIdCommand(
    Guid BookingId,
    Guid ResponsibleId) : IRequest;

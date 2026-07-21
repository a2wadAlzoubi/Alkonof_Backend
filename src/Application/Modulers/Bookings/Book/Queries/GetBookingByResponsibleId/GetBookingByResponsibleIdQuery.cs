using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookingByResponsibleId;

public sealed record GetBookingByResponsibleIdQuery(Guid ResponsibleId) : IRequest<List<BookingDto>>;

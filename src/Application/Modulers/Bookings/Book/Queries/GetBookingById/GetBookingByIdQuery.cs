using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookingById;

public sealed record GetBookingByIdQuery(Guid BookingId) : IRequest<BookingDto?>;

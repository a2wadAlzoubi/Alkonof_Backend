using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetExpiredBooking;

public sealed record GetExpiredBookingQuery : IRequest<List<BookingDto>>;

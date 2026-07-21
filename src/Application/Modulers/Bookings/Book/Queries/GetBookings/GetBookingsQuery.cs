using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookings;

public sealed record GetBookingsQuery : IRequest<List<BookingDto>>;

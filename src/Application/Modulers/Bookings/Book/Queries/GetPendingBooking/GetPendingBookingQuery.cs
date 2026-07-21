using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetPendingBooking;

public sealed record GetPendingBookingQuery : IRequest<List<BookingDto>>;

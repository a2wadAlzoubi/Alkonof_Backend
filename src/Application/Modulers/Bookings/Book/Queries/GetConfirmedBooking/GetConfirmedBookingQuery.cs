using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetConfirmedBooking;

public sealed record GetConfirmedBookingQuery : IRequest<List<BookingDto>>;

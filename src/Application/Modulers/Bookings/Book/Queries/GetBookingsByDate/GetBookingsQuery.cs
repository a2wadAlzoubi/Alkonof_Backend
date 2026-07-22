using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using Domain.DateHelper;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookings;

public sealed record GetBookingsQuery(TimeRange Range = TimeRange.None) : IRequest<List<BookingDto>>;

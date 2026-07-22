using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using Domain.DateHelper;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookingByUserId;

public sealed record GetBookingByUserIdDateQuery(Guid UserId , TimeRange Range) : IRequest<List<BookingDto>>;

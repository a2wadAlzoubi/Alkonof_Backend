using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Domain.DateHelper;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookingByUserIdStatusDate;

public sealed record GetBookingByUserIdStatusDateQuery(Guid UserId , BookingStatus Status = BookingStatus.Confirmed , TimeRange Range = TimeRange.None) : IRequest<List<BookingDto>>;

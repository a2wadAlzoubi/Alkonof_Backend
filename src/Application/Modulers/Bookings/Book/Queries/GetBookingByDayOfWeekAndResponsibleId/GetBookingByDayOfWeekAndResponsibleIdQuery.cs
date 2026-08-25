using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookingByDayOfWeekAndResponsibleId;

public sealed record GetBookingByDayOfWeekAndResponsibleIdQuery(
    Guid ResponsibleId,
    DayOfWeek DayOfWeek) : IRequest<List<BookingDto>>;

using Alkonof_Backend.Application.Modulers.Bookings.Book.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Queries.GetBookingByCustomerId;

public sealed record GetBookingByCustomerIdQuery(Guid CustomerId) : IRequest<List<BookingDto>>;

using Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Queries.GetOrderBookingByCustomerId;

public sealed record GetOrderBookingByCustomerIdQuery(Guid CustomerId) : IRequest<List<OrderBookingDto>>;

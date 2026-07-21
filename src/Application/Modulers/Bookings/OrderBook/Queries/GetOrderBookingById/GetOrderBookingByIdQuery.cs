using Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Queries.GetOrderBookingById;

public sealed record GetOrderBookingByIdQuery(Guid OrderBookingId) : IRequest<OrderBookingDto?>;

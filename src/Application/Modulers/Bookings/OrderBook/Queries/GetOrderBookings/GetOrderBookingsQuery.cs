using Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Queries.GetOrderBookings;

public sealed record GetOrderBookingsQuery : IRequest<List<OrderBookingDto>>;

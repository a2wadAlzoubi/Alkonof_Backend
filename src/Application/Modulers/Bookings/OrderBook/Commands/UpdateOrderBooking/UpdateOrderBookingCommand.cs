using Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Commands.UpdateOrderBooking;

public sealed record UpdateOrderBookingCommand(OrderBookingDto Dto) : IRequest;

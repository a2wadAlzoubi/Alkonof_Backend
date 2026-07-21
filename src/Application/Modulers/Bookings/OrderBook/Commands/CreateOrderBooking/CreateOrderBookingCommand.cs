using Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Commands.CreateOrderBooking;

public sealed record CreateOrderBookingCommand(CreateOrderBookingDto Dto) : IRequest<Guid>;

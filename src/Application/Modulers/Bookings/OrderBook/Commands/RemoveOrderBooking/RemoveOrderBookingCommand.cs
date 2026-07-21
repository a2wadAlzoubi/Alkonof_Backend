using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.OrderBook.Commands.RemoveOrderBooking;

public sealed record RemoveOrderBookingCommand(Guid OrderBookingId) : IRequest;

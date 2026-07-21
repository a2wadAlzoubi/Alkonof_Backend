using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.CancellBooking;

public sealed record CancellBookingCommand(Guid BookingId) : IRequest;

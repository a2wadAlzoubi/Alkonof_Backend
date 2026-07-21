using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.ExpireBooking;

public sealed record ExpireBookingCommand(Guid BookingId) : IRequest;

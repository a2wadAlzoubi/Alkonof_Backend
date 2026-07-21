using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.RemoveBooking;

public sealed record RemoveBookingCommand(Guid BookingId) : IRequest;

using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.UpdateConfirmedAtBooking;

public sealed record UpdateConfirmedAtBookingCommand(Guid BookingId , DateTimeOffset ConfirmedAt) : IRequest;

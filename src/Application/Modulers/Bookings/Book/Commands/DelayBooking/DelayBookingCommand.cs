using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.DelayBooking;

public sealed record DelayBookingCommand(Guid BookingId) : IRequest;

using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.ConfirmBooking;

public sealed record ConfirmBookingCommand(Guid BookingId, Guid CustomerId, Guid ResponsibleId) : IRequest;

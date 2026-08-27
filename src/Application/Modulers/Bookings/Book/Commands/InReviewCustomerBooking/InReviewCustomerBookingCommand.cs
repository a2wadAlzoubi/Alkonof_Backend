using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.InReviewCustomerBooking;

public sealed record InReviewCustomerBookingCommand(Guid BookingId, Guid CustomerId, Guid ResponsibleId) : IRequest;

using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.InReviewResponsibleBooking;

public sealed record InReviewResponsibleBookingCommand(Guid BookingId,Guid ResponsibleId) : IRequest;

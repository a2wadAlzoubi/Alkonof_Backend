using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.InReviewResponsibleBooking;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Exceptions;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.InReviewResponsibleBooking;

internal sealed class InReviewResponsibleBookingCommandHandler(IApplicationDbContext context , ICurrentUserProvider currentUser, IPublishEndpoint publishEndpoint)
    : IRequestHandler<InReviewResponsibleBookingCommand>
{
    public async Task Handle(InReviewResponsibleBookingCommand request, CancellationToken cancellationToken)
    {
        if (currentUser.Role != UserRole.Admin) { throw new InvalidOperationException("Current user is not authenticated."); }
        var booking = await context.Booking
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking is null)
        {
            throw new NotFoundException(nameof(Booking), request.BookingId.ToString());
        }

        booking.InReviewResponsibleBookingStatus();

        await publishEndpoint.Publish(new BookingConfirmedEvent(booking.Id), cancellationToken);

        await context.SaveChangesAsync(cancellationToken);
    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Exceptions;
using Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.DelayBooking;

internal sealed class DelayBookingCommandHandler(IApplicationDbContext context , ICurrentUserProvider currentUser)
    : IRequestHandler<DelayBookingCommand>
{
    public async Task Handle(DelayBookingCommand request, CancellationToken cancellationToken)
    {
        if (currentUser.Role != UserRole.Admin) { throw new InvalidOperationException("Current user is not authenticated."); }
        var booking = await context.Booking
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking is null)
        {
            throw new NotFoundException(nameof(Booking), request.BookingId.ToString());
        }

        booking.DelayBookingStatus(request.BookingId);

        await context.SaveChangesAsync(cancellationToken);
    }
}

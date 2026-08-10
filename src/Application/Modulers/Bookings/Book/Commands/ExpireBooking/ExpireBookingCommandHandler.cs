using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Exceptions;
using Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.ExpireBooking;

internal sealed class ExpireBookingCommandHandler(IApplicationDbContext context , ICurrentUserProvider currentUser)
    : IRequestHandler<ExpireBookingCommand>
{
    public async Task Handle(ExpireBookingCommand request, CancellationToken cancellationToken)
    {
        if (currentUser.Role != UserRole.Admin) { throw new InvalidOperationException("Current user is not authenticated."); }
        var booking = await context.Booking
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking is null)
        {
            throw new NotFoundException(nameof(Booking), request.BookingId.ToString());
        }

        booking.ExpireBooking(request.BookingId);

        await context.SaveChangesAsync(cancellationToken);
    }
}

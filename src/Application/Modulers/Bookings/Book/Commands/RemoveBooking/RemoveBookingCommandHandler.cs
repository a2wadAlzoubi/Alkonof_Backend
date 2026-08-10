using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Application.Abstractions;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.RemoveBooking;

internal sealed class RemoveBookingCommandHandler(IApplicationDbContext context , ICurrentUserProvider currentUser)
    : IRequestHandler<RemoveBookingCommand>
{
    public async Task Handle(RemoveBookingCommand request, CancellationToken cancellationToken)
    {
        if (currentUser.Role != UserRole.Admin) { throw new InvalidOperationException("Current user is not authenticated."); }
        var booking = await context.Booking
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking is null)
        {
            throw new NotFoundException(nameof(Booking), request.BookingId.ToString());
        }

        context.Booking.Remove(booking);
        await context.SaveChangesAsync(cancellationToken);
    }
}

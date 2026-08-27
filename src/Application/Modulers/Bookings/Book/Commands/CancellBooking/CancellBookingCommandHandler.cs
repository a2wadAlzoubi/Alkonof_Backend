using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.CancellBooking;

internal sealed class CancellBookingCommandHandler(IApplicationDbContext context , ICurrentUserProvider currentUser)
    : IRequestHandler<CancellBookingCommand>
{
    public async Task Handle(CancellBookingCommand request, CancellationToken cancellationToken)
    {
        if (currentUser.Role == UserRole.Responsible) { throw new InvalidOperationException("Current user is not authenticated."); }
        var booking = await context.Booking
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking is null)
        {
            throw new NotFoundException(nameof(Booking), request.BookingId.ToString());
        }

        booking.CancellBooking();

        await context.SaveChangesAsync(cancellationToken);
    }
}

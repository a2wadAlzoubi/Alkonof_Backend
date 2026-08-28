using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.UpdateConfirmedAtBooking;

internal sealed class UpdateConfirmedAtBookingHandler(IApplicationDbContext context , ICurrentUserProvider currentUser)
    : IRequestHandler<UpdateConfirmedAtBookingCommand>
{
    public async Task Handle(UpdateConfirmedAtBookingCommand request, CancellationToken cancellationToken)
    {
        if (currentUser.Role != UserRole.Admin) 
        {
            throw new InvalidOperationException("Current user is not authenticated."); 
        }
        var booking = await context.Booking
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking is null)
        {
            throw new NotFoundException(nameof(Booking), request.BookingId.ToString());
        }

        booking.UpdateConfirmedAt(request.ConfirmedAt);

        await context.SaveChangesAsync(cancellationToken);
    }
}

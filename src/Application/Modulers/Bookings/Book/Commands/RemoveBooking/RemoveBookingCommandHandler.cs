using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.RemoveBooking;

internal sealed class RemoveBookingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<RemoveBookingCommand>
{
    public async Task Handle(RemoveBookingCommand request, CancellationToken cancellationToken)
    {
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

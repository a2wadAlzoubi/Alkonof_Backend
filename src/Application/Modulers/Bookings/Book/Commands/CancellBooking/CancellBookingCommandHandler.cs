using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.CancellBooking;

internal sealed class CancellBookingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CancellBookingCommand>
{
    public async Task Handle(CancellBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await context.Booking
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking is null)
        {
            throw new NotFoundException(nameof(Booking), request.BookingId.ToString());
        }

        booking.CancellBooking(request.BookingId);

        await context.SaveChangesAsync(cancellationToken);
    }
}

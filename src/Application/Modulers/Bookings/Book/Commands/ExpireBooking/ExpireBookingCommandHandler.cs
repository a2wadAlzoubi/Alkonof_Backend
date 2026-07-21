using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.ExpireBooking;

internal sealed class ExpireBookingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<ExpireBookingCommand>
{
    public async Task Handle(ExpireBookingCommand request, CancellationToken cancellationToken)
    {
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

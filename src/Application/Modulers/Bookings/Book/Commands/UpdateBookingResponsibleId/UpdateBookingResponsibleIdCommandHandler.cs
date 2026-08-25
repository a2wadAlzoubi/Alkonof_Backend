using Alkonof_Backend.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.UpdateBookingResponsibleId;

internal sealed class UpdateBookingResponsibleIdCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateBookingResponsibleIdCommand>
{
    public async Task Handle(UpdateBookingResponsibleIdCommand request, CancellationToken cancellationToken)
    {
        var booking = await context.Booking
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking is null)
        {
            // Or throw a custom exception
            return;
        }

        booking.GetType().GetProperty("ResponsibleId")?.SetValue(booking, request.ResponsibleId);

        await context.SaveChangesAsync(cancellationToken);
    }
}

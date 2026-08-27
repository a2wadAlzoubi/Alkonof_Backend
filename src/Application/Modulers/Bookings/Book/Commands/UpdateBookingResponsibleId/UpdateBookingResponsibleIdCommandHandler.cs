using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
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
            throw new NotFoundException(nameof(Booking), request.BookingId.ToString());
        }

        booking.GetType().GetProperty("ResponsibleId")?.SetValue(booking, request.ResponsibleId);

        await context.SaveChangesAsync(cancellationToken);
    }
}

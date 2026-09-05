using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Entities.Identity;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.UpdateBookingResponsibleId;

internal sealed class UpdateBookingResponsibleIdCommandHandler(IApplicationDbContext context, IPublishEndpoint publishEndpoint)
    : IRequestHandler<UpdateBookingResponsibleIdCommand>
{
    public async Task Handle(UpdateBookingResponsibleIdCommand request, CancellationToken cancellationToken)
    {
        var booking = await context.Booking
            .Include(b => b.Responsible)
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking is null || booking.Responsible is null)
        {
            throw new NotFoundException(nameof(Booking), nameof(booking));
        }
        var responsible = booking.Responsible;
        var oldHour = booking.ConfirmedAt;

        if (responsible == null)
        {
            throw new NotFoundException(nameof(User), nameof(responsible));
        }

        booking.GetType().GetProperty("ResponsibleId")?.SetValue(booking, request.ResponsibleId);

        await publishEndpoint.Publish(new UpdateBookingStatusEvent(booking.Id), cancellationToken);

        await publishEndpoint.Publish(new UnResevedHourEvent(responsible.Id, oldHour.Hour), cancellationToken);

        await context.SaveChangesAsync(cancellationToken);
    }
}

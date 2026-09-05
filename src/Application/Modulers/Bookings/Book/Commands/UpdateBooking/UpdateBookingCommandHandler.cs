using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Mapster;
using MassTransit;
using MassTransit.Transports;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.UpdateBooking;

internal sealed class UpdateBookingCommandHandler(IApplicationDbContext context , ICurrentUserProvider currentUser, IPublishEndpoint publishEndpoint)
    : IRequestHandler<UpdateBookingCommand>
{
    public async Task Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        if (currentUser.Role != UserRole.Admin) { throw new InvalidOperationException("Current user is not authenticated."); }
        var booking = await context.Booking
            .Include(b => b.Responsible)
            .FirstOrDefaultAsync(b => b.Id == request.Dto.Id, cancellationToken);

        if (booking is null || booking.Responsible is null)
        {
            throw new NotFoundException(nameof(Booking), request.Dto.Id.ToString());
        }
        var responsible = booking.Responsible;
        var oldHour = booking.ConfirmedAt;
        if (responsible == null)
        {
            throw new NotFoundException(nameof(User), responsible!.Id.ToString());
        }

        booking.UpdateBooking(
            request.Dto.Title,
            request.Dto.CustomerId,
            request.Dto.ResponsibleId,
            request.Dto.ConfirmedAt,
            request.Dto.CustomerAnswer,
            request.Dto.ResponsibleAnswer,
            request.Dto.Status,
            request.Dto.ContractId
        );
        booking.Updated();


        booking.GetType().GetProperty("ResponsibleId")?.SetValue(booking, request.Dto.ResponsibleId);

        await publishEndpoint.Publish(new UpdateBookingStatusEvent(booking.Id), cancellationToken);

        await publishEndpoint.Publish(new UnResevedHourEvent(responsible.Id, oldHour.Hour), cancellationToken);
        await publishEndpoint.Publish(new ResevedHourEvent(request.Dto.ResponsibleId, request.Dto.ConfirmedAt.Hour), cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);
    }
}

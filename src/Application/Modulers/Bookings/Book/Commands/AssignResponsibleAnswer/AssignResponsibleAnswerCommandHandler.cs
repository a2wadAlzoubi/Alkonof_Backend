using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Exceptions;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.AssignResponsibleAnswer;

internal sealed class AssignResponsibleAnswerCommandHandler(IApplicationDbContext context, IPublishEndpoint publishEndpoint)
    : IRequestHandler<AssignResponsibleAnswerCommand>
{
    public async Task Handle(AssignResponsibleAnswerCommand request, CancellationToken cancellationToken)
    {
        var booking = await context.Booking
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking is null) 
        {
            throw new NotFoundException(nameof(Booking), request.BookingId.ToString());
        }
        if (booking.CustomerAnswer != Decision.None)
        {
            throw new NotFoundException(nameof(Booking), "anable to add Responsible answer before responsible Approved");
        }

        booking.AssignResposibleAnswer(request.Decision);

        await publishEndpoint.Publish(new ResponsibleAnswerAssignedEvent(booking.Id, request.Decision), cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

    }
}

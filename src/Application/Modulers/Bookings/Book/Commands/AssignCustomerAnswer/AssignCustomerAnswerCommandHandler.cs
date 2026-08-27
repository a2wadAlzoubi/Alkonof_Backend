using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Exceptions;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.AssignCustomerAnswer;

internal sealed class AssignCustomerAnswerCommandHandler(IApplicationDbContext context, IPublishEndpoint publishEndpoint)
    : IRequestHandler<AssignCustomerAnswerCommand>
{
    public async Task Handle(AssignCustomerAnswerCommand request, CancellationToken cancellationToken)
    {
        var booking = await context.Booking
            .FirstOrDefaultAsync(b => b.Id == request.BookingId, cancellationToken);

        if (booking is null)
        {
            throw new NotFoundException(nameof(Booking), request.BookingId.ToString());
        }


        if (booking.ResponsibleAnswer != Decision.Approved)
        {
            throw new NotFoundException(nameof(Booking), "anable to add Customer answer before responsible Approved");
        }
            
        booking.AssignCustomerAnswer(request.Decision);
        booking.Updated();

        await publishEndpoint.Publish(new CustomerAnswerAssignedEvent(booking.Id, request.Decision), cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);
    }
}

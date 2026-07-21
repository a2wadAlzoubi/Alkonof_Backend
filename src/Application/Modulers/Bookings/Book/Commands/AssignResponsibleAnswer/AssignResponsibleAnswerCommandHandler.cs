using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.AssignResponsibleAnswer;

internal sealed class AssignResponsibleAnswerCommandHandler(IApplicationDbContext context)
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

        booking.AssignResposibleAnswer(request.Decision, request.BookingId, request.ResponsibleId);

        await context.SaveChangesAsync(cancellationToken);
    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.AssignCustomerAnswer;

internal sealed class AssignCustomerAnswerCommandHandler(IApplicationDbContext context)
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

        booking.AssignCustomerAnswer(request.Decision, request.BookingId, request.CustomerId);

        await context.SaveChangesAsync(cancellationToken);
    }
}

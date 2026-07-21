using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.UpdateBooking;

internal sealed class UpdateBookingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateBookingCommand>
{
    public async Task Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await context.Booking
            .FirstOrDefaultAsync(b => b.Id == request.Dto.Id, cancellationToken);

        if (booking is null)
        {
            throw new NotFoundException(nameof(Booking), request.Dto.Id.ToString());
        }

        booking.UpdateBooking(
            request.Dto.Title,
            request.Dto.ExpiredAt,
            request.Dto.CustomerId,
            request.Dto.ResponsibleId,
            request.Dto.CustomerAnswer,
            request.Dto.ResponsibleAnswer,
            request.Dto.Status,
            request.Dto.ContractId
        );

        await context.SaveChangesAsync(cancellationToken);
    }
}

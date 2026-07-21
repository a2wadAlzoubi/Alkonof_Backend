using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.CreateBooking;

internal sealed class CreateBookingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateBookingCommand, Guid>
{
    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = Booking.CreateBooking(
            request.Dto.Title,
            request.Dto.ExpiredAt,
            request.Dto.CustomerId,
            request.Dto.ResponsibleId,
            request.Dto.CustomerAnswer,
            request.Dto.ResponsibleAnswer,
            request.Dto.Status,
            request.Dto.ContractId
        );

        await context.Booking.AddAsync(booking, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return booking.Id;
    }
}

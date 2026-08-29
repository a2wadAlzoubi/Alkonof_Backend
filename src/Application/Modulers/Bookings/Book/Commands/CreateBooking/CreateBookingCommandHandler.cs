using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.CreateBooking;

//[Authorize]

//internal sealed class CreateBookingCommandHandler(IApplicationDbContext context , ICurrentUserProvider currentUser)
internal sealed class CreateBookingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateBookingCommand, Guid>
{
    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        //if (currentUser.Role != UserRole.Admin) { throw new InvalidOperationException("Current user is not authenticated."); }
        var booking = Booking.CreateBooking(
            request.Dto.Title,
            request.Dto.CustomerId,
            request.Dto.ResponsibleId,
            request.Dto.ConfirmedAt,
            request.Dto.Status,
            request.Dto.ContractId
        );

        await context.Booking.AddAsync(booking, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);

        return booking.Id;
    }
}

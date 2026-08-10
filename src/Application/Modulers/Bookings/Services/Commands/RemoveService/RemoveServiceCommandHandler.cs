using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Application.Abstractions;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Commands.RemoveService;

internal sealed class RemoveServiceCommandHandler(IApplicationDbContext context , ICurrentUserProvider currentUser)
    : IRequestHandler<RemoveServiceCommand>
{
    public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
    {
        if (currentUser.Role != UserRole.Admin) { throw new InvalidOperationException("Current user is not authenticated."); }
        var service = await context.Service
            .FirstOrDefaultAsync(bt => bt.Id == request.ServiceId, cancellationToken);

        if (service is null)
        {
            throw new NotFoundException(nameof(Service), request.ServiceId.ToString());
        }

        context.Service.Remove(service);
        await context.SaveChangesAsync(cancellationToken);
    }
}

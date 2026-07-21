using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Commands.RemoveService;

internal sealed class RemoveServiceCommandHandler(IApplicationDbContext context)
    : IRequestHandler<RemoveServiceCommand>
{
    public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
    {
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

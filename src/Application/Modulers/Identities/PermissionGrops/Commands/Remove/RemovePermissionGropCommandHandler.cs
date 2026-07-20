using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Commands.Remove;

internal sealed class RemovePermissionGropCommandHandler(IApplicationDbContext context)
    : IRequestHandler<RemovePermissionGropCommand>
{
    public async Task Handle(RemovePermissionGropCommand request, CancellationToken cancellationToken)
    {
        var permissionGrop = await context.PermissionGrop
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (permissionGrop is null)
        {
            throw new NotFoundException(nameof(PermissionGrop), request.Id.ToString());
        }

        context.PermissionGrop.Remove(permissionGrop);

        await context.SaveChangesAsync(cancellationToken);
    }
}

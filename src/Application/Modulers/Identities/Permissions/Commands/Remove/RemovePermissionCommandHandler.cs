using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Commands.Remove;

internal sealed class RemovePermissionCommandHandler(IApplicationDbContext context)
    : IRequestHandler<RemovePermissionCommand>
{
    public async Task Handle(RemovePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = await context.Permission
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (permission is null)
        {
            throw new NotFoundException(nameof(Permission), request.Id.ToString());
        }

        context.Permission.Remove(permission);

        await context.SaveChangesAsync(cancellationToken);
    }
}

using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.GrantPermissions.Commands;

internal sealed class GrantPermissionCommandHandler(IApplicationDbContext context)
    : IRequestHandler<GrantPermissionCommand>
{
    public async Task Handle(GrantPermissionCommand request, CancellationToken cancellationToken)
    {
        var user = await context.User
            .FindAsync(new object[] { request.Dto.UserId }, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.Dto.UserId.ToString());
        }

        var permission = await context.Permission
            .FindAsync(new object[] { request.Dto.PermissionId }, cancellationToken);

        if (permission is null)
        {
            throw new NotFoundException(nameof(Permission), request.Dto.PermissionId.ToString());
        }

        user.GrantPermission(permission.Id);

        await context.SaveChangesAsync(cancellationToken);
    }
}

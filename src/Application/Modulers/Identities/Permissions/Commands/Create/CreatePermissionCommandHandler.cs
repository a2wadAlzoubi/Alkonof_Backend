using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Commands.Create;

internal sealed class CreatePermissionCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreatePermissionCommand, Guid>
{
    public async Task<Guid> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var existingPermission = await context.Permission
            .FirstOrDefaultAsync(p => p.Name == request.Dto.Name, cancellationToken);

        if (existingPermission is not null)
        {
            throw new InvalidOperationException("A permission with this name already exists.");
        }

        var permission = Permission.Create(request.Dto.Name, request.Dto.Description);

        context.Permission.Add(permission);

        await context.SaveChangesAsync(cancellationToken);

        return permission.Id;
    }
}

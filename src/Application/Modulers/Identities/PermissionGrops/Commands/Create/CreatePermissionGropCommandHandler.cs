using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Commands.Create;

internal sealed class CreatePermissionGropCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreatePermissionGropCommand, Guid>
{
    public async Task<Guid> Handle(CreatePermissionGropCommand request, CancellationToken cancellationToken)
    {
        var existingGroup = await context.PermissionGrop
            .FirstOrDefaultAsync(pg => pg.Name == request.Dto.Name, cancellationToken);

        if (existingGroup is not null)
        {
            throw new InvalidOperationException("A permission group with this name already exists.");
        }

        var permissionGrop = PermissionGrop.Create(request.Dto.Name, request.Dto.Description, request.Dto.PermissionId);

        context.PermissionGrop.Add(permissionGrop);

        await context.SaveChangesAsync(cancellationToken);

        return permissionGrop.Id;
    }
}

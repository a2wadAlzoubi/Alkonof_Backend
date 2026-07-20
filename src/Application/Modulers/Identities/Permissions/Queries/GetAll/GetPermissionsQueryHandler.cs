using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Permissions.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Queries.GetAll;

internal sealed class GetPermissionsQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetPermissionsQuery, List<PermissionDto>>
{
    public async Task<List<PermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
    {
        var permissions = await context.Permission
            .Select(p => new PermissionDto(p.Id, p.Name, p.Description))
            .ToListAsync(cancellationToken);

        return permissions;
    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Queries.GetAll;

internal sealed class GetPermissionGropsQueryHandler(IApplicationDbContext context) 
    : IRequestHandler<GetPermissionGropsQuery, List<PermissionGropDto>>
{
    public async Task<List<PermissionGropDto>> Handle(GetPermissionGropsQuery request, CancellationToken cancellationToken)
    {
        var permissionGrops = await context.PermissionGrop
            .Select(pg => new PermissionGropDto(pg.Id, pg.Name, pg.Description, pg.PermissionId))
            .ToListAsync(cancellationToken);

        return permissionGrops;
    }
}

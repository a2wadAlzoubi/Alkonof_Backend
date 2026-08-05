using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Permissions.Dtos;
using Mapster;

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Queries.GetPermissionsByType;

public class GetPermissionsByTypeQueryHandler : IRequestHandler<GetPermissionsByTypeQuery, IEnumerable<PermissionDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPermissionsByTypeQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PermissionDto>> Handle(GetPermissionsByTypeQuery request, CancellationToken cancellationToken)
    {
        return await _context.Permission
            .AsNoTracking()
            .Where(p => p.PermissionType == request.PermissionType)
            .ProjectToType<PermissionDto>()
            .ToListAsync(cancellationToken);
    }
}

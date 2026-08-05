using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;
using Mapster;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Queries.GetPermissionGropsByOperation;

public class GetPermissionGropsByOperationQueryHandler : IRequestHandler<GetPermissionGropsByOperationQuery, IEnumerable<PermissionGropDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPermissionGropsByOperationQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PermissionGropDto>> Handle(GetPermissionGropsByOperationQuery request, CancellationToken cancellationToken)
    {
        return await _context.PermissionGrop
            .AsNoTracking()
            .Where(p => p.OperationPermission == request.OperationPermission)
            .ProjectToType<PermissionGropDto>()
            .ToListAsync(cancellationToken);
    }
}

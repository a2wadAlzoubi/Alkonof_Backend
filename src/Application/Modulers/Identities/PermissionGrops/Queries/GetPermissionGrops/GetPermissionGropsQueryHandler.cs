using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;
using Mapster;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Queries.GetPermissionGrops;

public class GetPermissionGropsQueryHandler : IRequestHandler<GetPermissionGropsQuery, IEnumerable<PermissionGropDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPermissionGropsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PermissionGropDto>> Handle(GetPermissionGropsQuery request, CancellationToken cancellationToken)
    {
        return await _context.PermissionGrop
            .AsNoTracking()
            .ProjectToType<PermissionGropDto>()
            .ToListAsync(cancellationToken);
    }
}

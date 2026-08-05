using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStagesByProjectId;

public class GetStagesByProjectIdQueryHandler : IRequestHandler<GetStagesByProjectIdQuery, List<StageDto>>
{
    private readonly IApplicationDbContext _context;

    public GetStagesByProjectIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<StageDto>> Handle(GetStagesByProjectIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Stage
            .ProjectToType<StageDto>()
            .Where(s => s.ProjectId == request.ProjectId)
            .ToListAsync(cancellationToken);
    }
}

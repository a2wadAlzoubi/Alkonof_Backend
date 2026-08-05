using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStageImagesByStageId;

public class GetStageImagesByStageIdQueryHandler : IRequestHandler<GetStageImagesByStageIdQuery, List<StageImageDto>>
{
    private readonly IApplicationDbContext _context;

    public GetStageImagesByStageIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<StageImageDto>> Handle(GetStageImagesByStageIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.StageImage
            .ProjectToType<StageImageDto>()
            .Where(si => si.StageId == request.StageId)
            .ToListAsync(cancellationToken);
    }
}

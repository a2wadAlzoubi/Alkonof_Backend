using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetTasksByStageId;

public class GetTasksByStageIdQueryHandler : IRequestHandler<GetTasksByStageIdQuery, List<TaskDto>>
{
    private readonly IApplicationDbContext _context;

    public GetTasksByStageIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskDto>> Handle(GetTasksByStageIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.TaskTabel
            .ProjectToType<TaskDto>()
            .Where(t => t.StageId == request.StageId)
            .ToListAsync(cancellationToken);
    }
}

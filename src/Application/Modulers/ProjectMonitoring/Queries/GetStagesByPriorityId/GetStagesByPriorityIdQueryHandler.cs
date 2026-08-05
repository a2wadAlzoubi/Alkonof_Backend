using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStagesByPriorityId;

public class GetStagesByPriorityIdQueryHandler : IRequestHandler<GetStagesByPriorityIdQuery, List<TaskDto>>
{
    private readonly IApplicationDbContext _context;

    public GetStagesByPriorityIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskDto>> Handle(GetStagesByPriorityIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.TaskTabel
            .ProjectToType<TaskDto>()
            .Where(t => t.Priority == request.Priority)
            .ToListAsync(cancellationToken);
    }
}

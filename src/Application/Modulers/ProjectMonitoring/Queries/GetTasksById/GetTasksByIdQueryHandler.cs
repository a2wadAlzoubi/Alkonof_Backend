using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetTasksById;

public class GetTasksByIdQueryHandler : IRequestHandler<GetTasksByIdQuery, TaskDto?>
{
    private readonly IApplicationDbContext _context;

    public GetTasksByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TaskDto?> Handle(GetTasksByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.TaskTabel
            .ProjectToType<TaskDto>()
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
    }
}

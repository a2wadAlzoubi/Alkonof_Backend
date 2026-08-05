using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetProjectById;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDto?>
{
    private readonly IApplicationDbContext _context;

    public GetProjectByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProjectDto?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Project
            .ProjectToType<ProjectDto>()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
    }
}

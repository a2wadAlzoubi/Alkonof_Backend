using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateProjectCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = Project.CreateProject(
            request.CreateProjectDto.Title,
            request.CreateProjectDto.Description,
            request.CreateProjectDto.Location,
            request.CreateProjectDto.EndDate,
            0 
        );

        _context.Project.Add(project);

        await _context.SaveChangesAsync(cancellationToken);

        return project.Id;
    }
}

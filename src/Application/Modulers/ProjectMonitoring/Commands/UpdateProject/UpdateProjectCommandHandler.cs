using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProjectCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Project.FindAsync(new object[] { request.UpdateProjectDto.Id }, cancellationToken);

        if (project == null)
        {
            throw new NotFoundException(nameof(Project), request.UpdateProjectDto.Id.ToString());
        }

        project.UpdateProject(
            request.UpdateProjectDto.Title,
            request.UpdateProjectDto.Description,
            request.UpdateProjectDto.Location,
            request.UpdateProjectDto.EndDate,
            project.Progress,
            project.Status
        );

        await _context.SaveChangesAsync(cancellationToken);

    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.ChangeProjectStatus;

public class ChangeProjectStatusCommandHandler : IRequestHandler<ChangeProjectStatusCommand>
{
    private readonly IApplicationDbContext _context;

    public ChangeProjectStatusCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(ChangeProjectStatusCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Project.FindAsync(new object[] { request.ChangeProjectStatusDto.Id }, cancellationToken);

        if (project == null)
        {
            throw new NotFoundException(nameof(Project), request.ChangeProjectStatusDto.Id.ToString());
        }

        project.ChangeProjectState(project.Id, request.ChangeProjectStatusDto.NewStatus);

        await _context.SaveChangesAsync(cancellationToken);
    }


}

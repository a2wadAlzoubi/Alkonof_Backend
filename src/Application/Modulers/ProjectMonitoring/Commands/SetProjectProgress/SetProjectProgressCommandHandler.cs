using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.SetProjectProgress;

public class SetProjectProgressCommandHandler : IRequestHandler<SetProjectProgressCommand>
{
    private readonly IApplicationDbContext _context;

    public SetProjectProgressCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(SetProjectProgressCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Project.FindAsync(new object[] { request.SetProjectProgressDto.Id }, cancellationToken);

        if (project == null)
        {
            throw new NotFoundException(nameof(Project), request.SetProjectProgressDto.Id.ToString());
        }

        project.SetProgress(project.Id , request.SetProjectProgressDto.Progress);

        await _context.SaveChangesAsync(cancellationToken);

    }
}

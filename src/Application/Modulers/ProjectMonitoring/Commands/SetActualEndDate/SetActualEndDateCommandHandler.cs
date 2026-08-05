using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.SetActualEndDate;

public class SetActualEndDateCommandHandler : IRequestHandler<SetActualEndDateCommand>
{
    private readonly IApplicationDbContext _context;

    public SetActualEndDateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(SetActualEndDateCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Project.FindAsync(new object[] { request.SetActualEndDateDto.Id }, cancellationToken);

        if (project == null)
        {
            throw new NotFoundException(nameof(Project), request.SetActualEndDateDto.Id.ToString());
        }

        project.SetActualEndDate(request.SetActualEndDateDto.ActualEndDate);

        await _context.SaveChangesAsync(cancellationToken);

    }
}

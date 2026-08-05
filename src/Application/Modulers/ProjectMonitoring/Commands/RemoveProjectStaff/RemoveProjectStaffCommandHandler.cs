using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.RemoveProjectStaff;

public class RemoveProjectStaffCommandHandler : IRequestHandler<RemoveProjectStaffCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveProjectStaffCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveProjectStaffCommand request, CancellationToken cancellationToken)
    {
        var projectStaff = await _context.ProjectStaff.FindAsync(new object[] { request.Id }, cancellationToken);

        if (projectStaff == null)
        {
            throw new NotFoundException(nameof(ProjectStaff), request.Id.ToString());
        }

        _context.ProjectStaff.Remove(projectStaff);

        await _context.SaveChangesAsync(cancellationToken);

    }
}

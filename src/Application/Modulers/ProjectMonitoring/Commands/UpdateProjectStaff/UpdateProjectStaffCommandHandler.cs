using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateProjectStaff;

public class UpdateProjectStaffCommandHandler : IRequestHandler<UpdateProjectStaffCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProjectStaffCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProjectStaffCommand request, CancellationToken cancellationToken)
    {
        var projectStaff = await _context.ProjectStaff.FindAsync(new object[] { request.UpdateProjectStaffDto.Id }, cancellationToken);

        if (projectStaff == null)
        {
            throw new NotFoundException(nameof(ProjectStaff), request.UpdateProjectStaffDto.Id.ToString());
        }

        projectStaff.UpdateProjectStaff(
            request.UpdateProjectStaffDto.ProjectId,
            request.UpdateProjectStaffDto.ResponsibalId
        );

        await _context.SaveChangesAsync(cancellationToken);

    }
}

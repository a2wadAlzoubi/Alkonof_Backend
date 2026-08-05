using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateProjectStaff;

public class CreateProjectStaffCommandHandler : IRequestHandler<CreateProjectStaffCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateProjectStaffCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateProjectStaffCommand request, CancellationToken cancellationToken)
    {
        var projectStaff = ProjectStaff.CreateProjectStaff(
            request.CreateProjectStaffDto.ProjectId,
            request.CreateProjectStaffDto.ResponsibalId
        );

        _context.ProjectStaff.Add(projectStaff);

        await _context.SaveChangesAsync(cancellationToken);

        return projectStaff.Id;
    }
}

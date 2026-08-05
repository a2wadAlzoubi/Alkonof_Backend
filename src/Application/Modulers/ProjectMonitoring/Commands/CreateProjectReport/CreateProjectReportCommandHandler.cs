using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateProjectReport;

public class CreateProjectReportCommandHandler : IRequestHandler<CreateProjectReportCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateProjectReportCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateProjectReportCommand request, CancellationToken cancellationToken)
    {
        var projectReport = ProjectReport.CreateProjectReport(
            request.CreateProjectReportDto.ProjectId,
            request.CreateProjectReportDto.Type,
            request.CreateProjectReportDto.Title,
            request.CreateProjectReportDto.Content
        );

        _context.ProjectReport.Add(projectReport);

        await _context.SaveChangesAsync(cancellationToken);

        return projectReport.Id;
    }
}

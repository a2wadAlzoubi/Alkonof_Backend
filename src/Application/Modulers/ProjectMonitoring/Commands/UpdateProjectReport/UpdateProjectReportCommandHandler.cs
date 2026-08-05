using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateProjectReport;

public class UpdateProjectReportCommandHandler : IRequestHandler<UpdateProjectReportCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProjectReportCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProjectReportCommand request, CancellationToken cancellationToken)
    {
        var projectReport = await _context.ProjectReport.FindAsync(new object[] { request.UpdateProjectReportDto.Id }, cancellationToken);

        if (projectReport == null)
        {
            throw new NotFoundException(nameof(ProjectReport), request.UpdateProjectReportDto.Id.ToString());
        }

        projectReport.UpdateProjectReport(
            request.UpdateProjectReportDto.ProjectId,
            request.UpdateProjectReportDto.Type,
            request.UpdateProjectReportDto.Title,
            request.UpdateProjectReportDto.Content
        );

        await _context.SaveChangesAsync(cancellationToken);

    }
}

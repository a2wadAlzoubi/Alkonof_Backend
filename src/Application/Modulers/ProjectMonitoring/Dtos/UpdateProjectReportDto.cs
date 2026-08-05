using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;

public class UpdateProjectReportDto
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public ReportType Type { get; set; }
}

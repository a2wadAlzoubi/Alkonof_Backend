namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;

public class ProjectReportDto
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string ReportType { get; set; } = string.Empty;
    public Guid ProjectId { get; set; }
}

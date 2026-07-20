using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;

namespace Alkonof_Backend.Domain.Entities.ProjectMonitoring;

public class ProjectReport : BaseAuditableEntity
{
    private ProjectReport()
    {
        
    }
    private ProjectReport(Guid id, Guid projectId, string title, string content , ReportType type = ReportType.Daily)
    {
        Id = id;
        ProjectId = projectId;
        Type = type;
        Title = title;
        Content = content;
    }

    [Required]
    public ReportType Type {  get; private set; }
    [Required]
    public string Title {  get; private set; } = string.Empty;
    public string Content {  get; private set; } = string.Empty;

    // Relations
    public Project? Project { get; private set; }
    [Required]
    public Guid ProjectId { get; private set; }

    public static ProjectReport CreateProjectReport(Guid stageId, ReportType type, string title, string content)
    {
        var report = new ProjectReport(Guid.NewGuid() , stageId , title , content, type);
        return report;
    }
    public void UpdateProjectReport(Guid projectId, ReportType type, string title, string content)
    {
        ProjectId = projectId;
        Type = type;
        Title = title;
        Content = content;
    }
    public void ChangeReportType(ReportType type)
    {
        Type = type;
    }

}

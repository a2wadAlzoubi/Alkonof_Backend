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
    private ProjectReport(Guid id, Guid stageId, string title, string content , ReportType type = ReportType.Daily)
    {
        Id = id;
        StageId = stageId;
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
    public Stage? Stage { get; private set; }
    [Required]
    public Guid StageId { get; private set; }

    public static ProjectReport CreateProjectType(Guid stageId, ReportType type, string title, string content)
    {
        var report = new ProjectReport(Guid.NewGuid() , stageId , title , content, type);
        return report;
    }
    public void UpdateProjectType(Guid stageId, ReportType type, string title, string content)
    {
        StageId = stageId;
        Type = type;
        Title = title;
        Content = content;
    }
    public void ChangeReportType(ReportType type)
    {
        Type = type;
    }

}

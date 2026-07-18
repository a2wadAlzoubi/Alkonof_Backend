using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;

namespace Alkonof_Backend.Domain.Entities.ProjectMonitoring;

public class ProjectReport : BaseAuditableEntity
{
    private ProjectReport()
    {
        
    }
    private ProjectReport(Guid id, Guid stageId, ReportType type, string title, string content)
    {
        Id = id;
        StageId = stageId;
        Type = type;
        Title = title;
        Content = content;
    }


    public ReportType Type {  get; private set; }
    public string Title {  get; private set; } = string.Empty;
    public string Content {  get; private set; } = string.Empty;

    // Relations
    public Stage? Stage { get; private set; }
    public Guid StageId { get; private set; }

}

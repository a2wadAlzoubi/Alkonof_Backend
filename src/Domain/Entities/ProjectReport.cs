using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class ProjectReport : BaseAuditableEntity
{
    private ProjectReport()
    {
        
    }
    private ProjectReport(Guid id, Guid stageId, ReprotType type, string title, string content)
    {
        Id = id;
        StageId = stageId;
        Type = type;
        Title = title;
        Content = content;
    }


    public ReprotType Type {  get; private set; }
    public string Title {  get; private set; } = string.Empty;
    public string Content {  get; private set; } = string.Empty;

    // Relations
    public Stage? Stage { get; private set; }
    public Guid StageId { get; private set; }

}

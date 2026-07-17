using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.GeneralEnum;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;

namespace Alkonof_Backend.Domain.Entities.ProjectMonitoring;

public class TaskTabel : BaseAuditableEntity
{
    private TaskTabel(
        Guid id ,
        string title,
        string description,
        PriorityLevel priority,
        DateTimeOffset startedDate,
        DateTimeOffset actualEndedDate,
        double progress,
        Guid stageId)
    {
        Id = id ;
        Title = title;
        Description = description;
        Priority = priority;
        StartedDate = startedDate;
        ActualEndedDate = actualEndedDate;
        Progress = progress;
        StageId = stageId;
    }

    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public PriorityLevel Priority { get; private set; } = PriorityLevel.None;
    public DateTimeOffset StartedDate { get; private set; }
    public DateTimeOffset ActualEndedDate { get; private set; }
    public double Progress { get; private set; }
    // Relations
    public Stage? Stage { get; private set; }
    public Guid StageId { get; private set; }
}

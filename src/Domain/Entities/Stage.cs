using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class Stage : BaseAuditableEntity
{
    private Stage(Guid id , string name, string description, Task_StageStatus status, double progress , DateTimeOffset startedDate, DateTimeOffset actualEndedDate , Guid projectId)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.Status = status;
        this.Progress = progress;
        this.StartedDate = startedDate;
        this.ActualEndedDate = actualEndedDate;
        this.ProjectId = projectId;
    }

    private Stage()
    {
        
    }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Task_StageStatus Status { get; private set; } = Task_StageStatus.NotStarted;
    public DateTimeOffset StartedDate { get; private set; }
    public DateTimeOffset ActualEndedDate { get; private set; }
    public double Progress { get; private set; }

    // Relations
    public Project? Project { get; private set; }
    public Guid ProjectId { get; private set; }
    public ICollection<StageImage> StageImages { get; private set; } = new List<StageImage>();
    public ICollection<ProjectReport> ProjectReport { get; private set; } = new List<ProjectReport>();
    public ICollection<TaskTabel> Tasks { get; private set; } = new List<TaskTabel>();
}

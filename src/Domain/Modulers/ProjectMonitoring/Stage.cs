using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;
using Alkonof_Backend.Domain.Modulers.ProjectMonitoring.Events.Stages;

namespace Alkonof_Backend.Domain.Entities.ProjectMonitoring;

public class Stage : BaseAuditableEntity
{
    private Stage(Guid id, string name, string description, double progress, DateTimeOffset startedDate, DateTimeOffset actualEndedDate, Guid projectId, StageStatus status = StageStatus.NotStarted)
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
    [Required]
    [StringLength(05)]
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    [Required]
    public StageStatus Status { get; private set; } = StageStatus.NotStarted;
    [Required]
    public DateTimeOffset StartedDate { get; private set; }
    public DateTimeOffset ActualEndedDate { get; private set; }
    [Required]
    public double Progress { get; private set; }

    // Relations
    public Project? Project { get; private set; }
    [Required]
    public Guid ProjectId { get; private set; }
    public ICollection<StageImage> StageImages { get; private set; } = new List<StageImage>();
    public ICollection<TaskTabel> Tasks { get; private set; } = new List<TaskTabel>();

    public static Stage CreateStage(string name, string description, double progress, DateTimeOffset startedDate, DateTimeOffset actualEndedDate, Guid projectId, StageStatus status = StageStatus.NotStarted)
    {
        var stage = new Stage(Guid.NewGuid(), name, description, progress, startedDate, actualEndedDate, projectId, status);
        stage.AddDomainEvent(new StageCreatedEvent(stage.Id, status));
        return stage;
    }
    public void UpdateStage(string name, string description, double progress, DateTimeOffset startedDate, DateTimeOffset actualEndedDate, Guid projectId, StageStatus status = StageStatus.NotStarted)
    {
        this.Name = name;
        this.Description = description;
        this.Status = status;
        this.Progress = progress;
        this.StartedDate = startedDate;
        this.ActualEndedDate = actualEndedDate;
        this.ProjectId = projectId;
    }
    public void ChangeStageStatus(Guid stageId, StageStatus status)
    {
        Status = status;
        switch (status)
        {
            case StageStatus.InProgress : AddDomainEvent(new StageStartedEvent(stageId, status));
                break;
            case StageStatus.Completed : AddDomainEvent(new StageCompletedEvent(stageId, status));
                break;
            case StageStatus.Cancelled : AddDomainEvent(new StageCancelledEvent(stageId, status));
                break;

            default: break;
        }
    }
    public void SetProgress(Guid stageId ,double progress)
    {
        Progress = progress;
        AddDomainEvent(new ProgressStageUpdatedEvent(stageId, progress));
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;
using Alkonof_Backend.Domain.Modulers.ProjectMonitoring.Events.Tasks;

namespace Alkonof_Backend.Domain.Entities.ProjectMonitoring;

public class TaskTabel : BaseAuditableEntity
{
    private TaskTabel(
        Guid id ,
        string title,
        string description,
        DateTimeOffset startedDate,
        DateTimeOffset actualEndedDate,
        double progress,
        Guid stageId,
        PriorityLevel priority
        )
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
    [Required]
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    [Required]
    public PriorityLevel Priority { get; private set; } = PriorityLevel.None;
    [Required]
    public DateTimeOffset StartedDate { get; private set; }
    public DateTimeOffset ActualEndedDate { get; private set; }
    [Required]
    public double Progress { get; private set; }
    // Relations
    public Stage? Stage { get; private set; }
    [Required]
    public Guid StageId { get; private set; }
    public static TaskTabel CreateTask(
        string title,
        string description,
        DateTimeOffset startedDate,
        DateTimeOffset actualEndedDate,
        double progress,
        Guid stageId,
        PriorityLevel priority = PriorityLevel.None
        )
    {
        var task = new TaskTabel(Guid.NewGuid(), title, description, startedDate, actualEndedDate, progress, stageId, priority);
        task.AddDomainEvent(new TaskCreatedEvent(task.Id));
        return task;
    }
    public void UpdateTask(
        string title,
        string description,
        PriorityLevel priority,
        DateTimeOffset startedDate,
        DateTimeOffset actualEndedDate,
        double progress,
        Guid stageId)
    {

        Title = title;
        Description = description;
        Priority = priority;
        StartedDate = startedDate;
        ActualEndedDate = actualEndedDate;
        Progress = progress;
        StageId = stageId;
    }
    public void ChangePriorityTask(Guid taskId , PriorityLevel priority)
    {
        Priority = priority; 
        AddDomainEvent(new TaskPriorityChangedEvent(taskId , Priority));
    }
    
}

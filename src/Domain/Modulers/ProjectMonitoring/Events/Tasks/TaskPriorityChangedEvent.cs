using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.ProjectMonitoring.Events.Tasks;

public class TaskPriorityChangedEvent : BaseEvent
{
    public TaskPriorityChangedEvent(Guid taskId, PriorityLevel priority)
    {
        TaskId = taskId;
        Priority = priority;
    }

    public Guid TaskId { get; set; }
    public PriorityLevel Priority { get; set; }
}

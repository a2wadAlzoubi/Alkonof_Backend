using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.ProjectMonitoring.Events.Tasks;

public class TaskCreatedEvent : BaseEvent
{
    public TaskCreatedEvent(Guid taskId)
    {
        TaskId = taskId;
    }

    public Guid TaskId { get; set; }
}

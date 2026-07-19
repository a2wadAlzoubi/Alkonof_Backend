using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.ProjectMonitoring.Events.Projects;

public class ProgressProjectUpdatedEvent: BaseEvent
{
    public ProgressProjectUpdatedEvent(Guid projectId, double progress)
    {
        ProjectId = projectId;
        Progress = progress;
    }

    public Guid ProjectId { get; set; }
    public double Progress { get; set; }
}

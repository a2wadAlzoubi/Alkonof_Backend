using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.ProjectMonitoring.Events.Projects;

public class ProjectCreatedEvent:BaseEvent
{
    public ProjectCreatedEvent(Guid projectId)
    {
        ProjectId = projectId;
    }

    public Guid ProjectId { get; set; }
}


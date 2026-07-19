using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;

namespace Alkonof_Backend.Domain.Modulers.ProjectMonitoring.Events.Projects;

public class ProjectStatusChangedEvent : BaseEvent
{
    public ProjectStatusChangedEvent(Guid projectId, ProjectStatus projectStatus)
    {
        ProjectId = projectId;
        ProjectStatus = projectStatus;
    }

    public Guid ProjectId { get; set; }
    public ProjectStatus ProjectStatus { get; set; }
}

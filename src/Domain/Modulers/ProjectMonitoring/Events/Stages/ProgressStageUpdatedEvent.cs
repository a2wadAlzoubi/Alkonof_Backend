using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.ProjectMonitoring.Events.Stages;

public class ProgressStageUpdatedEvent : BaseEvent
{
    public ProgressStageUpdatedEvent(Guid stageId, double progress)
    {
        StageId = stageId;
        Progress = progress;
    }

    public Guid StageId { get; set; }
    public double Progress { get; set; }
}

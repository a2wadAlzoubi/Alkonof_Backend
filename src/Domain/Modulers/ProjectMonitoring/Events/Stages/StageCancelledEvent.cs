using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;

namespace Alkonof_Backend.Domain.Modulers.ProjectMonitoring.Events.Stages;

public class StageCancelledEvent : BaseEvent
{
    public StageCancelledEvent(Guid stageId, StageStatus stageStatus)
    {
        StageId = stageId;
        StageStatus = stageStatus;
    }

    public Guid StageId { get; set; }
    public StageStatus StageStatus { get; set; }
}

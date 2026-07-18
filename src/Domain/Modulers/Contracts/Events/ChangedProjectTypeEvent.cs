using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.Contracts.Enum;

namespace Alkonof_Backend.Domain.Modulers.Contracts.Events;

public class ChangedProjectTypeEvent : BaseEvent
{
    public ChangedProjectTypeEvent(Guid contractId, ProjectType projectType)
    {
        ContractId = contractId;
        ProjectType = projectType;
    }

    public Guid ContractId { get; set; }
    public ProjectType ProjectType { get; set; }
}

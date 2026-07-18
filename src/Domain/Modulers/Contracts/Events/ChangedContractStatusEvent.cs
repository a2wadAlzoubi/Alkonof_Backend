using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.Contracts.Enum;

namespace Alkonof_Backend.Domain.Modulers.Contracts.Events;

public class ChangedContractStatusEvent : BaseEvent
{
    public ChangedContractStatusEvent(Guid contractId, ContractStatus contractStatus)
    {
        ContractId = contractId;
        ContractStatus = contractStatus;
    }

    public Guid ContractId { get; set; }
    public ContractStatus ContractStatus { get; set; }
}

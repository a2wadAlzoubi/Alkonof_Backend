using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Identity.IdentityEvents;

public class SoftRemoveUserEvent : BaseEvent
{
    public SoftRemoveUserEvent(Guid UserId)
    {
        this.UserId = UserId;
    }
    public Guid UserId { get; }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Identity.IdentityEvents;

public class ProfileUpdatedEvent : BaseEvent
{
    public ProfileUpdatedEvent(Guid UserId)
    {
        this.UserId = UserId;
    }
    public Guid UserId { get; }
}

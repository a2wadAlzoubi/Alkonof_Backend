using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Identity.IdentityEvents;

public class UserPermissionAssignedEvent : BaseEvent
{
    public UserPermissionAssignedEvent(Guid UserId, Guid PermissionId)
    {
        this.UserId = UserId;
        this.PermissionId = PermissionId;
    }
    public Guid UserId { get; }
    public Guid PermissionId { get; }
}

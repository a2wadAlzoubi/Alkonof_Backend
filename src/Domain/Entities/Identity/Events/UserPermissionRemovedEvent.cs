namespace Alkonof_Backend.Domain.Entities.Identity.IdentityEvents;

public class UserPermissionRemovedEvent : BaseEvent
{
    public UserPermissionRemovedEvent(Guid UserId, Guid PermissionId)
    {
        this.UserId = UserId;
        this.PermissionId = PermissionId;
    }
    public Guid UserId { get; }
    public Guid PermissionId{ get; }
}

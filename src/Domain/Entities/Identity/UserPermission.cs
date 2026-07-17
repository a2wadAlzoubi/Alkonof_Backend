using Alkonof_Backend.Domain.Entities.Identity.IdentityEvents;

namespace Alkonof_Backend.Domain.Entities.Identity;

public class UserPermission : BaseAuditableEntity
{
    private UserPermission()
    {

    }
    private UserPermission(Guid id, Guid userId, Guid permissionId, bool isGranted)
    {
        Id = id;
        UserId = userId;
        PermissionId = permissionId;
        IsGranted = isGranted;
    }

    public bool IsGranted { get; private set; } = false;

    // Relations :
    public User? User { get; private set; }
    public Guid UserId { get; private set; }
    public Permission? Permission { get; private set; }
    public Guid? PermissionId { get; private set; }

    public void AssignPermission(Guid userId , Guid permissionId)
    {
        new UserPermission(Guid.NewGuid(), userId, permissionId, true);

        AddDomainEvent(new UserPermissionAssignedEvent(userId , permissionId));
    }
    public void UpdatePermission( Guid userId , Guid permissionId)
    {
        UserId = userId;
        PermissionId = permissionId;
        AddDomainEvent(new UserPermissionAssignedEvent(userId, permissionId));
    }
    public void RemovePermission( Guid userId , Guid permissionId)
    {
        UserId = userId;
        PermissionId = null;
        IsGranted = false;
        AddDomainEvent(new UserPermissionRemovedEvent(userId, permissionId));
    }


}

using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class UserPermission : BaseAuditableEntity
{
    private UserPermission()
    {

    }
    private UserPermission(Guid id, Guid userId, Guid permissionId, bool isGranted, User user, Permission permission)
    {
        Id = id;
        UserId = userId;
        PermissionId = permissionId;
        IsGranted = isGranted;
    }

    public bool IsGranted { get; private set; }

    // Relations :
    public User? User { get; private set; }
    public Guid UserId { get; private set; }
    public Permission? Permission { get; private set; }
    public Guid PermissionId { get; private set; }
}

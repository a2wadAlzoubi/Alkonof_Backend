using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class UserPermission : BaseAuditableEntity
{
    private UserPermission()
    {

    }
    private UserPermission(int id, Guid userId, Guid permissionId, bool isGranted, User user, Permission permission)
    {
        Id = id;
        UserId = userId;
        PermissionId = permissionId;
        IsGranted = isGranted;
        User = user;
        Permission = permission;
    }

    public bool IsGranted { get; set; }

    // Relations :
    public User? User { get; set; }
    public Guid UserId { get; set; }
    public Permission? Permission { get; set; }
    public Guid PermissionId { get; set; }
}

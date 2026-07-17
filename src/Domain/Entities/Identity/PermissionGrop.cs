using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Identity;

public class PermissionGrop : BaseAuditableEntity
{
    private PermissionGrop()
    {
        
    }
    private PermissionGrop(Guid id ,string name, string description , Guid? permissionId)
    {
        Id = id;
        Name = name;
        Description = description;
        PermissionId = permissionId;
    }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    // Relations
    public Permission? Permission { get; private set; }
    public Guid? PermissionId { get; private set; }

    public static PermissionGrop Create(string name, string description , Guid? permissionId)
    {
        return new PermissionGrop(Guid.NewGuid(),  name, description , permissionId);
    }
    public void Update(string name, string description, Guid? permissionId)
    {
        Name = name;
        Description = description;
    }
}

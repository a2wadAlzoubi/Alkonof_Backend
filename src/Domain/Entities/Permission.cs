using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class Permission : BaseAuditableEntity
{
    private Permission()
    {
        
    }
    private Permission(Guid id, string name, string description , Guid PermissionGropId)
    {
        Id = id;
        Name = name;
        Description = description;
        this.PermissionGropId = PermissionGropId;
    }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public PermissionGrop? PermissionGrop { get; private set; }
    public Guid PermissionGropId { get; private set; }
    public ICollection<UserPermission> UserPermissions { get; private set; } = new List<UserPermission>();

}

using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class PermissionGrop : BaseAuditableEntity
{
    private PermissionGrop()
    {
        
    }
    private PermissionGrop(Guid id ,string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public ICollection<Permission> Permissions { get; private set; } = new List<Permission>();
}

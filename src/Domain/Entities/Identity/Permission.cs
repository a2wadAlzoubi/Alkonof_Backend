using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Identity;

public class Permission : BaseAuditableEntity
{
    private Permission()
    {
        
    }
    private Permission(Guid id , string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public ICollection<PermissionGrop> PermissionGrops { get; private set; } = new List<PermissionGrop>();
    public ICollection<UserPermission> UserPermissions { get; private set; } = new List<UserPermission>();

    public static Permission Create(string name, string description)
    {
        return new Permission(Guid.NewGuid(), name, description);
    }
    public void Update( string name, string description)
    {
        Name = name;
        Description = description;
    }



}

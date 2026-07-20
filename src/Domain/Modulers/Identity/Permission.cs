using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    [Required]
    [StringLength(50, MinimumLength = 2)] public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public ICollection<PermissionGrop> PermissionGrops { get; private set; } = new List<PermissionGrop>();
    public ICollection<User> Users { get; private set; } = new List<User>();

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

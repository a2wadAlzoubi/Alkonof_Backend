using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Domain.Entities.Identity;

public class Permission : BaseAuditableEntity
{
    private Permission()
    {
        
    }
    private Permission(Guid id , PermissionType permissionType)
    {
        Id = id;
        PermissionType = permissionType;
    }


    public PermissionType PermissionType { get; set; }
    public ICollection<PermissionGrop> PermissionGrops { get; private set; } = new List<PermissionGrop>();
    public ICollection<User> Users { get; private set; } = new List<User>();

    public static Permission Create(PermissionType permissionType)
    {
        return new Permission(Guid.NewGuid() , permissionType);
    }
    public void Update(PermissionType permissionType)
    {
        PermissionType = permissionType;
    }



}

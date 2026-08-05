using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics;
using System.Text;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Domain.Entities.Identity;

public class PermissionGrop : BaseAuditableEntity
{
    private PermissionGrop()
    {
        
    }
    private PermissionGrop(Guid id , OperationPermission operationPermission , Guid? permissionId)
    {
        Id = id;
        this.OperationPermission = operationPermission;
        PermissionId = permissionId;
    }

    public OperationPermission OperationPermission { get; private set; }
    // Relations
    public Permission? Permission { get; private set; }
    public Guid? PermissionId { get; private set; }

    public static PermissionGrop Create( OperationPermission operationPermission, Guid? permissionId)
    {
        return new PermissionGrop(Guid.NewGuid(), operationPermission, permissionId);
    }
    public void Update(OperationPermission operationPermission, Guid? permissionId)
    {
        PermissionId = permissionId;
        this.OperationPermission = OperationPermission;
    }
}

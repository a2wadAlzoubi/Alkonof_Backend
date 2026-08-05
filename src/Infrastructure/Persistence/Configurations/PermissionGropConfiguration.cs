using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alkonof_Backend.Infrastructure.Persistence.Configurations;

public class PermissionGropConfiguration : IEntityTypeConfiguration<PermissionGrop>
{
    public void Configure(EntityTypeBuilder<PermissionGrop> builder)
    {
        var permissionGrops = new List<object>();

        // Admin Permissions
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Booking, PermissionId = PermissionConfiguration.AdminPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Meeting, PermissionId = PermissionConfiguration.AdminPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Scheduling, PermissionId = PermissionConfiguration.AdminPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Contract, PermissionId = PermissionConfiguration.AdminPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.ProjectStaff, PermissionId = PermissionConfiguration.AdminPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Service, PermissionId = PermissionConfiguration.AdminPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.GrantPermission, PermissionId = PermissionConfiguration.AdminPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.CreateUser, PermissionId = PermissionConfiguration.AdminPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Notification, PermissionId = PermissionConfiguration.AdminPermissionId });

        // Engineer Permissions
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Booking, PermissionId = PermissionConfiguration.EngineerPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Meeting, PermissionId = PermissionConfiguration.EngineerPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Scheduling, PermissionId = PermissionConfiguration.EngineerPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Contract, PermissionId = PermissionConfiguration.EngineerPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.CreateUser, PermissionId = PermissionConfiguration.EngineerPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.CreateProject, PermissionId = PermissionConfiguration.EngineerPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.CreateStage, PermissionId = PermissionConfiguration.EngineerPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.CreateTask, PermissionId = PermissionConfiguration.EngineerPermissionId });

        // Formen Permissions
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Booking, PermissionId = PermissionConfiguration.FormenPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Meeting, PermissionId = PermissionConfiguration.FormenPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Scheduling, PermissionId = PermissionConfiguration.FormenPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.Contract, PermissionId = PermissionConfiguration.FormenPermissionId });
        permissionGrops.Add(new { Id = Guid.NewGuid(), OperationPermission = OperationPermission.CreateTask, PermissionId = PermissionConfiguration.FormenPermissionId });

        builder.HasData(permissionGrops);
    }
}

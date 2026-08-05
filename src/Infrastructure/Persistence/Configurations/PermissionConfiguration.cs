using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alkonof_Backend.Infrastructure.Persistence.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    // Define static Guids to be accessible from other configurations
    public static readonly Guid AdminPermissionId = new("0a794768-ab8a-4a07-b8a0-424b5e5df9d5");
    public static readonly Guid EngineerPermissionId = new("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b");
    public static readonly Guid FormenPermissionId = new("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a");
    public static readonly Guid BookingResponsiblePermissionId = new("f4d3e2c1-b0a9-4b8c-9a7b-6f5e4d3c2b1a");
    public static readonly Guid ComplainResponsiblePermissionId = new("a9b8c7d6-e5f4-4b3c-8a7b-6f5e4d3c2b1a");
    public static readonly Guid CustomerPermissionId = new("d1e2f3a4-b5c6-4b7d-8e9f-6f5e4d3c2b1a");

    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasData(
            new { Id = AdminPermissionId, PermissionType = PermissionType.Admin },
            new { Id = EngineerPermissionId, PermissionType = PermissionType.Engineer },
            new { Id = FormenPermissionId, PermissionType = PermissionType.Formen },
            new { Id = BookingResponsiblePermissionId, PermissionType = PermissionType.BookingResponsible },
            new { Id = ComplainResponsiblePermissionId, PermissionType = PermissionType.ComplainResponsible }
        );
    }
}

using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alkonof_Backend.Infrastructure.Data.Configurations;

public class PermissionGropConfiguration : IEntityTypeConfiguration<PermissionGrop>
{
    public void Configure(EntityTypeBuilder<PermissionGrop> builder)
    {


    }
}

using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alkonof_Backend.Infrastructure.Persistence.Configurations;

public class UserConfiguration() : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        Guid AdminPermissionId = new("0a794768-ab8a-4a07-b8a0-424b5e5df9d5");
        var passwordService = new PasswordService();
        builder.HasData(
                 new
                 {
                     Id = Guid.Parse("caf312c6-681b-44b4-9637-1c7e60ef7032"),
                     Name = "Awad",
                     Number = "0986174521",
                     Email = "awad@gmail.com",
                     Password = passwordService.Hash("Aaaa1111"),
                     CreatedAt = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero),
                     Role = UserRole.Admin,
                     IsDeleted = false,
                     PermissionId = AdminPermissionId
                 });


    }
}

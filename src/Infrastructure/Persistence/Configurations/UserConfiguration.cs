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
                     Id = Guid.Parse("3bf312c6-681b-44b4-9637-1c7e60e2e932"),
                     Name = "Awad",
                     Number = "0986174521",
                     Email = "awad@gmail.com",
                     Password = passwordService.Hash("Aaaa1111"),
                     CreatedAt = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero),
                     Role = UserRole.Admin,
                     IsDeleted = false,
                     PermissionId = AdminPermissionId
                 },

                new
                {
                    Id = Guid.Parse("1a7e5c9d-3f21-4b86-9c42-7d15e8a6b903"),
                    Name = "Ahmad",
                    Number = "0986123456",
                    Email = "ahmad@gmail.com",
                    Password = passwordService.Hash("Aaaa1111"),
                    CreatedAt = new DateTimeOffset(2026, 1, 2, 0, 0, 0, TimeSpan.Zero),
                    Role = UserRole.Customer,
                    IsDeleted = false
                },
                new
                {
                    Id = Guid.Parse("1a7e5c9d-3f21-1596-9c42-7d15e8e36903"),
                    Name = "Ahmad2",
                    Number = "0986123456",
                    Email = "ahmad2@gmail.com",
                    Password = passwordService.Hash("Aaaa1111"),
                    CreatedAt = new DateTimeOffset(2026, 1, 2, 0, 0, 0, TimeSpan.Zero),
                    Role = UserRole.Customer,
                    IsDeleted = false
                },
                new
                {
                    Id = Guid.Parse("1a7e5c9d-3f21-4b86-7e5c-7d15e8a6b903"),
                    Name = "Ahmad3",
                    Number = "0986123456",
                    Email = "ahmad3@gmail.com",
                    Password = passwordService.Hash("Aaaa1111"),
                    CreatedAt = new DateTimeOffset(2026, 1, 2, 0, 0, 0, TimeSpan.Zero),
                    Role = UserRole.Customer,
                    IsDeleted = false,
                    Specialization = Specialization.Civil
                },
                new
                {
                    Id = Guid.Parse("5b92d714-8e36-4c1a-a057-29f6b83dc9d5"),
                    Name = "Mohammad",
                    Number = "0986234567",
                    Email = "mohammad@gmail.com",
                    Password = passwordService.Hash("Aaaa1111"),
                    CreatedAt = new DateTimeOffset(2026, 1, 3, 0, 0, 0, TimeSpan.Zero),
                    Role = UserRole.Responsible,
                    IsDeleted = false,
                    Specialization = Specialization.Mechanical
                },
                new
                {
                    Id = Guid.Parse("e4386f21-7c95-4a03-bd18-52a9e6073f64"),
                    Name = "Omar",
                    Number = "0986345678",
                    Email = "omar@gmail.com",
                    Password = passwordService.Hash("Aaaa1111"),
                    CreatedAt = new DateTimeOffset(2026, 1, 4, 0, 0, 0, TimeSpan.Zero),
                    Role = UserRole.Responsible,
                    IsDeleted = false
                });



    }
}

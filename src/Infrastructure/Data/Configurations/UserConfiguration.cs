using System.Net.NetworkInformation;
using Alkonof_Backend.Domain.Entities;
using Alkonof_Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Alkonof_Backend.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
                 new
                 {
                     Id = Guid.Parse("caf312c6-681b-44b4-9637-1c7e60ef7032"),
                     Name = "Awad",
                     Number = "0368146785",
                     Email = "aa@gmail.com",
                     Password = "Aaaa 11111",
                     CreatedAt = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero),
                     Role = UserRole.customer,
                     Status = UserStatus.active
                 });
    }
}

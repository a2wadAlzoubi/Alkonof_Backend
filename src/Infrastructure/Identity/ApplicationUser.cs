using Alkonof_Backend.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Alkonof_Backend.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public User? User { get; }
}

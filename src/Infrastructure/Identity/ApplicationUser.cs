using Alkonof_Backend.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Alkonof_Backend.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{

    public User? User { get; }
}

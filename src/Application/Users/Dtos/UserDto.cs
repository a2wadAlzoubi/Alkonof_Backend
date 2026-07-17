using Alkonof_Backend.Domain.Common;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Application.Entities.Users.Dtos
{
    public class UserDto : BaseAuditableEntity 
    {
        public string Name { get; private set; } = string.Empty;
        public string Number { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public bool Status { get; private set; }
        public UserRole Role { get; private set; } = UserRole.customer;
    }
}

using Alkonof_Backend.Domain.Common;
using Alkonof_Backend.Domain.Enums;

namespace Application.Entities.Users.Dtos
{
    public class UserDto : BaseAuditableEntity 
    {
        public string FullName { get;  set; } = string.Empty;
        public string Number { get;  set; } = string.Empty;
        public string Email { get;  set; } = string.Empty;
        public string Password { get;  set; } = string.Empty;
        public UserType Type { get;  set; } = UserType.customer;
        public Guid IdentityId { get;  set; }
    }
}

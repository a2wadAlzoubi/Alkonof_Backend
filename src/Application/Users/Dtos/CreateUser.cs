using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Enums;

namespace Application.Entities.Users.Dtos
{
    public class CreateUser
    {

        public string Name { get; private set; } = string.Empty;
        public string Number { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public bool Status { get; private set; } 
        public UserRole Role { get; private set; } = UserRole.customer;
    }
}

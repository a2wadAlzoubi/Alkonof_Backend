using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Enums;

namespace Application.Entities.Users.Dtos
{
    public class CreateUser
    {

        public string    Name       { get; set; } = string.Empty;
        public string    Number     { get; set; } = string.Empty;
        public string   Email      { get; set; } = string.Empty;
        public string   Password   { get; set; } = string.Empty;
        public bool     Status       { get; set; } 
        public UserRole Role    { get; set; } = UserRole.customer;
    }
}

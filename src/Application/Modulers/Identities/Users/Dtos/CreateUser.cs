using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Enums;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Dtos
{
    public sealed record  CreateUserDto
    {

        public string    Name       { get; set; } = string.Empty;
        public string    Number     { get; set; } = string.Empty;
        public string   Email      { get; set; } = string.Empty;
        public string   Password   { get; set; } = string.Empty;
        public UserRole Role    { get; set; } = UserRole.customer;
        public bool IsDeleted { get; private set; } = false;
        public Guid? PermissionId { get; private set; }
    }
}

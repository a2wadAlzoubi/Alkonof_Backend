using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class User : BaseAuditableEntity
{
    private User()
    {
        
    }
    private User(Guid id, string fullName, string number, string email ,string password, UserStatus status, Role role )
    {
        Id = id;
        FullName = fullName;
        Number = number;
        Password = password;
        Email = email;
        Status = status;
        Role = role;
    }

    public string FullName { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Email { get; set; } =string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserStatus Status { get; set; } = UserStatus.unActive;
    public Role Role { get; set; } = Role.customer;

    public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

}

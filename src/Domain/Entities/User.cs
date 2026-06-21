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
    private User(int id, string fullName, string number, string email ,string password, string status, string role )
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
    public string Status { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

}

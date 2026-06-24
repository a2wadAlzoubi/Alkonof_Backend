using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Alkonof_Backend.Domain.Constants;

namespace Alkonof_Backend.Domain.Entities;

public class User : BaseAuditableEntity
{
    private User()
    {
        
    }
    private User(Guid id, Guid identityId , string fullName, string number, string email ,string password )
    {
        Id = id;
        FullName = fullName;
        Number = number;
        Password = password;
        Email = email;
        IdentityId = identityId;
    }

    public string FullName { get; private set; } = string.Empty;
    public string Number { get; private set; } = string.Empty;
    public string Email { get; private set; } =string.Empty;
    public string Password { get; private set; } = string.Empty;
    public UserType Type { get; private set; } = UserType.customer;
    public Guid IdentityId { get; private set; }

    public ICollection<UserPermission> UserPermissions { get; private set; } = new List<UserPermission>();

}

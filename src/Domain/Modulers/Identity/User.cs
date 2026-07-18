using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Alkonof_Backend.Domain.Entities.Audits;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Complains;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Entities.Identity.IdentityEvents;
using Alkonof_Backend.Domain.Entities.Notifications;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using Domain.RefreshTokens;

namespace Alkonof_Backend.Domain.Entities.Identity;

public class User : BaseAuditableEntity 
{
    private User()
    {
        
    }

    private User(
        Guid id ,
        string name,
        string number,
        string email,
        string password,
        UserRole role = UserRole.customer,
        bool isDeleted = false 
        )
    {
        Id = id;
        Name = name;
        Number = number;
        Email = email;
        Password = password;
        IsDeleted = isDeleted;
        Role = role;
    }
    [Required]
    [StringLength(50 , MinimumLength =2)]
    public string Name { get; private set; } = string.Empty;
    [Phone]
    [StringLength(20)]
    public string Number { get; private set; } = string.Empty;
    [Required]
    [EmailAddress]
    [StringLength(256)]
    public string Email { get; private set; } =string.Empty;
    [PasswordPropertyText]
    [Required]
    [StringLength(200)]
    public string Password { get; private set; } = string.Empty;
    public bool IsDeleted{ get; private set; } = false;
    public UserRole Role { get; private set; }


    // Relations

    public ICollection<OrderBooking>? OrderBookings { get; private set; }
    public ICollection<Booking>? ResponsibalBookings { get; private set; }
    public ICollection<Booking>? CustomerBookings { get; private set; }
    public ICollection<UserPermission>? UserPermissions { get; private set; }
    public ICollection<Complain>? Complains { get; private set; }
    public ICollection<AuditEntity>? AuditEntities { get; private set; }
    public ICollection<Notification>? Notifications { get; private set; }
    public ICollection<ProjectStaff>? ProjectStaffs { get; private set; }
    public ICollection<RefreshToken>? RefreshTokens { get; private set; }

    public static User Create(
        string name,
        string number,
        string email,
        string password,
        UserRole role = UserRole.customer,
        bool isDeleted = false)
    {
        return new User(Guid.NewGuid(), name, number, email, password , role , isDeleted);
    }
    public static User Register(string name, string number, string email, string password )
    {
        //AddDomainEvent(new UserRegisterEvent(userId , email));
        return new User(Guid.NewGuid(), name, number, email, password);

    }
    public void Update(
        string name,
        string number,
        string email,
        string password,
        UserRole role,
        bool isDeleted)
    {
        Name = name;
        Number = number;
        Email = email;
        Password = password;
        IsDeleted = isDeleted;
        Role = role;
    }
    public void UpdateEmail(string email , Guid userId)
    {
        Email = email;
        AddDomainEvent(new ProfileUpdatedEvent(userId));
    }

    public void UpdatePassword(string password, Guid userId)
    {
        Password = password;
        AddDomainEvent(new ProfileUpdatedEvent(userId));
    }
    public void SoftRemoneUser(Guid userId)
    {
        IsDeleted = false;
        AddDomainEvent(new SoftRemoveUserEvent(userId));
    }

    public void AssignRole(UserRole role)
    {
        Role = role;
    }



    public string GenerateSecurityHash()
    {
        return ComputeSha512Hash(Name + Password);
    }


    private static string ComputeSha512Hash(string rawData)
    {
        // Create a SHA256
        // ComputeHash - returns byte array
        var bytes = SHA512.HashData(Encoding.UTF8.GetBytes(rawData));

        // Convert byte array to a string
        var builder = new StringBuilder();
        foreach (var t in bytes)
        {
            builder.Append(t.ToString("x2", CultureInfo.InvariantCulture));
        }

        return builder.ToString();
    }

}

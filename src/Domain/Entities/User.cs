using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Domain.RefreshTokens;

namespace Alkonof_Backend.Domain.Entities;

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
        UserStatus status = UserStatus.unActive,
        UserRole role = UserRole.customer)
    {
        Id = id;
        Name = name;
        Number = number;
        Email = email;
        Password = password;
        Status = status;
        Role = role;
    }

    public string Name { get; private set; } = string.Empty;
    public string Number { get; private set; } = string.Empty;
    public string Email { get; private set; } =string.Empty;
    public string Password { get; private set; } = string.Empty;
    public UserStatus Status{ get; private set; }
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

    public static User Create(string name, string number, string email, string password, UserStatus status, UserRole role)
    {
        return new User(Guid.NewGuid(), name, number, email, password , status , role);
    }
    public static User Register(string name, string number, string email, string password)
    {
        return new User(Guid.NewGuid(), name, number, email, password);
    }
    //public decimal CalculateBalance => User_Accounts.Sum(ua=>ua.Transaction!.Amount);
    public void Update
        (string name, string number, string email, string password, UserStatus status, UserRole role)
    {
        Name = name;
        Number = number;
        Email = email;
        Password = password;
        Status = status;
        Role = role;
    }
    public void UpdateEmail(string email)
    {
        Email = email;
       
    }

    public void UpdatePassword(string password)
    {
        Password = password;
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

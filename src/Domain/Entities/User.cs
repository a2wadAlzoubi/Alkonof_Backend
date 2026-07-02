using System.Globalization;
using System.Security.Cryptography;
using System.Text;

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
        UserPermissions = new List<UserPermission>();
    }

    public string FullName { get; private set; } = string.Empty;
    public string Number { get; private set; } = string.Empty;
    public string Email { get; private set; } =string.Empty;
    public string Password { get; private set; } = string.Empty;
    public UserType Type { get; private set; } = UserType.customer;
    public Guid IdentityId { get; private set; }

    public ICollection<UserPermission>? UserPermissions { get; private set; }

    public static User Create(
      Guid identityId, string fullName, string number, string email, string password)
    {
        return new User(Guid.NewGuid(), identityId, fullName, number, email, password);
    }
    //public decimal CalculateBalance => User_Accounts.Sum(ua=>ua.Transaction!.Amount);
    public void Update(
        Guid id, Guid identityId, string fullName, string number, string email, string password)
    {
        this.Id = id;
        this.FullName = fullName;
        this.Number = number;
        this.Password = password;
        this.Email = email;
        this.IdentityId = identityId;
    }
    public void UpdateEmail(string email)
    {
        Email = email;
       
    }

    public void UpdatePassword(string password)
    {
        Password = password;
    }


    //public string GenerateSecurityHash()
    //{
    //    return ComputeSha512Hash(Name + Password);
    //}


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

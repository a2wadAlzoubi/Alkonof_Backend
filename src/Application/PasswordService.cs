using System.Security.Cryptography;
using System.Text;
using Alkonof_Backend.Application.Modulers.Identities.Users.Services;

namespace Application.Abstractions;

public sealed class PasswordService : IPasswordService
{
    public string Hash(string plainPassword)
    {
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(plainPassword)));
    }

    public bool Compare(string plainPassword, string hash)
    {
        return Hash(plainPassword).Equals(hash, StringComparison.Ordinal);
    }
    public bool CompareNH(string plainPassword, string hash)
    {
        return plainPassword == hash;
    }
}
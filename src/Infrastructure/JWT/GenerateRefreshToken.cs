using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Alkonof_Backend.Domain.Entities;
using Application.Abstractions.JWT;
using Application.Options;
using Domain.RefreshTokens;
using Microsoft.Extensions.Options;

namespace Infrastructure.JWT;

public class GenerateRefreshToken(IOptionsSnapshot<JwtOptions> jwtOptions) : IGenerateRefreshToken
{
    public RefreshToken GRefreshToken(string refreshToken, User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        return
            RefreshToken.Create(HashRefreshToken(refreshToken),
                DateTimeOffset.Now.AddMinutes(jwtOptions.Value.RefreshTokenLifetime),
                user.GenerateSecurityHash(), user.Id);
    }

    public string HashRefreshToken(string refreshToken)
    {
        var bits = SHA512.HashData(Encoding.UTF8.GetBytes(refreshToken));
        var builder = new StringBuilder();
        foreach (var t in bits)
        {
            builder.Append(t.ToString("x2", CultureInfo.InvariantCulture));
        }

        return builder.ToString();
    }
}

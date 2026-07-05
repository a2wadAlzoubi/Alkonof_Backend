using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Alkonof_Backend.Domain.Entities;
using Application.Abstractions.JWT;
using Application.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.JWT;

public class JwtGenerator(IOptionsSnapshot<JwtOptions> jwtOptions) : IJwtGenerator
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public string Generate(User user, Guid id)
    {
        var key = Encoding.UTF8.GetBytes(_jwtOptions.Key);
        ArgumentNullException.ThrowIfNull(user);
        List<Claim> claims =
        [
            new Claim("Id", user.Id.ToString()),
            new Claim("Name", user.Name),
            new Claim("Type", user.Role.ToString()),
            new Claim("RefreshTokenId", id.ToString())
        ];

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(_jwtOptions.AccessTokenLifetime),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
        );


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

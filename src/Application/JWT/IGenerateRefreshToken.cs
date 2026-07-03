using Alkonof_Backend.Domain.Entities;
using Domain.RefreshTokens;

namespace Application.Abstractions.JWT;

public interface IGenerateRefreshToken
{
    RefreshToken GRefreshToken(string refreshToken, User user);
    string HashRefreshToken(string refreshToken);
}

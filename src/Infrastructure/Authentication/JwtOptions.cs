using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Infrastructure.Authentication;

public sealed class JwtOptions
{
    public required string Key { get; init; } = default!;
    public required string Issuer { get; init; } = default!;
    public required string Audience { get; init; } = default!;
    public int AccessTokenLifetime { get; init; } 
    public int RefreshTokenLifetime { get; init; }
}

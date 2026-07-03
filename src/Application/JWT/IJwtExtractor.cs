using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Application.Abstractions.JWT;

public interface IJwtExtractor
{
    IList<Claim>? Extract(HttpContext httpContext);
    IList<Claim>? Extract(string token);
}

using Application.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Abstraction
{
    public sealed class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserProvider(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid Id
        {
            get
            {
                var userId = _httpContextAccessor
                    .HttpContext?
                    .User?
                    
                    .FindFirst("Id")?.Value!;

                    //.FirstOrDefault(c => c.Type == "userId")
                return Guid.TryParse(userId, out var guid)
                    ? guid
                    : Guid.Empty;
            }
        }


    }
}

//public sealed class CurrentUser : ICurrentUser
//{
//    private readonly IHttpContextAccessor _httpContextAccessor;

//    public CurrentUser(IHttpContextAccessor httpContextAccessor)
//    {
//        _httpContextAccessor = httpContextAccessor;
//    }

//    public Guid UserId =>
//        Guid.Parse(
//            _httpContextAccessor.HttpContext?
//                .User
//                .FindFirst("Id")?.Value!
//        );

//    public string? Role =>
//        _httpContextAccessor.HttpContext?
//            .User
//            .FindFirst(ClaimTypes.Role)?.Value;

//    public string? Name =>
//        _httpContextAccessor.HttpContext?
//            .User
//            .FindFirst("Name")?.Value;
//}

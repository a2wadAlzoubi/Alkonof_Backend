using Application.Authentication.Dtos;

namespace Application.Authentication.SignIn
{
    public sealed record LoginCommand : LoginRequest, IRequest<RefreshTokenResponce>;
    
}

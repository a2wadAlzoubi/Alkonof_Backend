using Application.Authentication.Dtos;

namespace Application.Authentication.SignIn
{
    public sealed record LoginCommand (LoginRequest Login) : IRequest<RefreshTokenResponce>;
    
}

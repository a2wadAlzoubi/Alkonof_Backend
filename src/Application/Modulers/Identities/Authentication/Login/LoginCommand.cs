using Alkonof_Backend.Application.Modulers.Identities.Authentication.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Authentication.Login
{
    public sealed record LoginCommand (LoginRequest Login) : IRequest<RefreshTokenResponce>;
    
}

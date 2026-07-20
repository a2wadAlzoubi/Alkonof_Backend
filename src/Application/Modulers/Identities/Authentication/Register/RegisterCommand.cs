using Alkonof_Backend.Application.Modulers.Identities.Authentication.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Authentication.Register
{
    public sealed record RegisterCommand (RegisterRequest Register) : IRequest<RefreshTokenResponce>;
}

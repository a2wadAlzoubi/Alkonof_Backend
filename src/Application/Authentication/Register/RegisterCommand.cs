using Application.Authentication.Dtos;

namespace Application.Authentication.Register
{
    public sealed record RegisterCommand(RegisterRequest Register) :  IRequest<RefreshTokenResponce>;
}

using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.UpdatePasswordForAdmin
{
    public sealed record UpdatePasswordForAdminCommand(UpdatePasswordDto PasswordDto) : IRequest<bool>;
}

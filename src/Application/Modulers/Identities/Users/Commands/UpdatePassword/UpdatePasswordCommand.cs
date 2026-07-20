using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Common.Models;
using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.UpdatePassword
{
    public sealed record UpdatePasswordCommand(UpdatePasswordDto PasswordDto) : IRequest<bool>;
}

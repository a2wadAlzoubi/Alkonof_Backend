
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Common.Models;
using Application.Entities.Users.Dtos;

namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.UpdatePassword
{
    public sealed record UpdatePasswordCommand(UpdatePasswordDto PasswordDto) : IRequest<bool>;
}

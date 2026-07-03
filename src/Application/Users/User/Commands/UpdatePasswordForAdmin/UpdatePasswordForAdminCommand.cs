using Application.Entities.Users.Dtos;

namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.UpdatePasswordForAdmin
{
    public sealed record UpdatePasswordForAdminCommand(UpdatePasswordDto PasswordDto) : IRequest<bool>;
}

using Application.Entities.Users.Dtos;

namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.Update;

public record UpdateUserCommand : IRequest
{
    public UserDto UserDto { get; set; } = new UserDto();
}

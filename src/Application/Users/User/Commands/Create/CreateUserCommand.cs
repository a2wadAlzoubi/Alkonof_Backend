using Application.Entities.Users.Dtos;

namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.Create;

public record CreateUserCommand : IRequest<Guid>
{
    public CreateUser CreateUser { get; init; } = new CreateUser();
}


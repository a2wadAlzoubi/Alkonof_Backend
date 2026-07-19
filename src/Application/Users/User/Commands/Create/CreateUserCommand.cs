using Application.Entities.Users.Dtos;

namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.Create;

public record CreateUserCommand(CreateUser CreateUser) : IRequest<Guid>;



namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.Delete;

public record DeleteUserCommand(Guid Id) : IRequest;

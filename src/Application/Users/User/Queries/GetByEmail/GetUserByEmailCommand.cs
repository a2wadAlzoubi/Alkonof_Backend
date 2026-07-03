using Application.Entities.Users.Dtos;

namespace Alkonof_Backend.Application.Users.ToDoUser.Queries.GetByEmail;

public record GetUserByEmailCommand(string email) : IRequest<UserDto>;

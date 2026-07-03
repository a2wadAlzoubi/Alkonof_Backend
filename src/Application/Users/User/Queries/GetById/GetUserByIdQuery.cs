using Application.Entities.Users.Dtos;

namespace Alkonof_Backend.Application.Users.ToDoUser.Queries.GetById;

public record GetUserByIdQuery(Guid UserId) : IRequest<UserDto>;

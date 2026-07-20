using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetById;

public record GetUserByIdQuery(Guid UserId) : IRequest<UserDto>;

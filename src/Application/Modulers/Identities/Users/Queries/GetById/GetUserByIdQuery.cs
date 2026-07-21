using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetById;

public sealed record GetUserByIdQuery(Guid Id) : IRequest<UserDto>;

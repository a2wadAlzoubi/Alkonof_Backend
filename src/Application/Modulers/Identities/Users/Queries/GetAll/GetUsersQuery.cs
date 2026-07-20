using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetAll;

public sealed record GetUsersQuery : IRequest<List<UserDto>>;

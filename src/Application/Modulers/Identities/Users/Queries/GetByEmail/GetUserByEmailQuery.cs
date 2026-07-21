using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetByEmail;

public sealed record GetUserByEmailQuery(string Email) : IRequest<UserDto>;

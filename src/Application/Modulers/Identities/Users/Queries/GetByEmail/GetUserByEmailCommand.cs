using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetByEmail;

public record GetUserByEmailCommand(string email) : IRequest<UserDto>;

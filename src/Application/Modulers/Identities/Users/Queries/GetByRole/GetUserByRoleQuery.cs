using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetByRole;

public sealed record GetUserByRoleQuery(UserRole Role) : IRequest<List<UserDto>>;

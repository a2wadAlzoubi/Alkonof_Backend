using Alkonof_Backend.Application.Modulers.Identities.Permissions.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Queries.GetAll;

public sealed record GetPermissionsQuery : IRequest<List<PermissionDto>>;

using Alkonof_Backend.Application.Modulers.Identities.Permissions.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Queries.GetPermissions;

public record GetPermissionsQuery : IRequest<IEnumerable<PermissionDto>>;

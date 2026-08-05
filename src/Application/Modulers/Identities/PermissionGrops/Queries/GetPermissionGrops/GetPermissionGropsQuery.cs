using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Queries.GetPermissionGrops;

public record GetPermissionGropsQuery : IRequest<IEnumerable<PermissionGropDto>>;

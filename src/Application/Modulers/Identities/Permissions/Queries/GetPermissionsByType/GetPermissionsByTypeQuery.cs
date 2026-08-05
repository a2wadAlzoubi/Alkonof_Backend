using Alkonof_Backend.Application.Modulers.Identities.Permissions.Dtos;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Queries.GetPermissionsByType;

public record GetPermissionsByTypeQuery(PermissionType PermissionType) : IRequest<IEnumerable<PermissionDto>>;

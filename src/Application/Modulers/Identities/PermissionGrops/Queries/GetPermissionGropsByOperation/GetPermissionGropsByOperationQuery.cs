using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Queries.GetPermissionGropsByOperation;

public record GetPermissionGropsByOperationQuery(OperationPermission OperationPermission) : IRequest<IEnumerable<PermissionGropDto>>;

using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;

public sealed record UpdatePermissionGropDto(
    Guid Id,
    OperationPermission OperationPermission,
    Guid? PermissionId
);

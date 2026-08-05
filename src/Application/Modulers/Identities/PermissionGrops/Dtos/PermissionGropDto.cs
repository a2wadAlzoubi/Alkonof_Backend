
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;

public sealed record PermissionGropDto(
    Guid Id,
    OperationPermission Permission,
    Guid? PermissionId
);

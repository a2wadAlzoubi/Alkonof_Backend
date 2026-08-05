using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Dtos;

public sealed record UpdatePermissionDto(
    Guid Id,
    PermissionType PermissionType
);

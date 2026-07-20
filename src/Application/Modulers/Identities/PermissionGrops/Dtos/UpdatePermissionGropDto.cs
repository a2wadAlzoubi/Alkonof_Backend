namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;

public sealed record UpdatePermissionGropDto(
    Guid Id,
    string Name,
    string Description,
    Guid? PermissionId
);

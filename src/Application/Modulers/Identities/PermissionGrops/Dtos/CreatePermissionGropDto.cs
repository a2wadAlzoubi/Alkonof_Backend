namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;

public sealed record CreatePermissionGropDto(
    string Name,
    string Description,
    Guid? PermissionId
);

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Dtos;

public sealed record UpdatePermissionDto(
    Guid Id,
    string Name,
    string Description
);

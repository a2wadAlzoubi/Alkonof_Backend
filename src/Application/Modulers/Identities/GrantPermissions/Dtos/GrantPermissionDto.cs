namespace Alkonof_Backend.Application.Modulers.Identities.GrantPermissions.Dtos;

public sealed record GrantPermissionDto(
    Guid UserId,
    Guid PermissionId
);

using Alkonof_Backend.Application.Modulers.Identities.GrantPermissions.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.GrantPermissions.Commands;

public sealed record GrantPermissionCommand(GrantPermissionDto Dto) : IRequest;

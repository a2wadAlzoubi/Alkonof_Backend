using Alkonof_Backend.Application.Modulers.Identities.Permissions.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Commands.Create;

public sealed record CreatePermissionCommand(CreatePermissionDto Dto) : IRequest<Guid>;

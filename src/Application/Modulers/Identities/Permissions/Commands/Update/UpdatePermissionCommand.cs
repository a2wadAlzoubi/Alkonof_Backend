using Alkonof_Backend.Application.Modulers.Identities.Permissions.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Commands.Update;

public sealed record UpdatePermissionCommand(UpdatePermissionDto Dto) : IRequest;

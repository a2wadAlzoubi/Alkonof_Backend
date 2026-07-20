using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Commands.Update;

public sealed record UpdatePermissionGropCommand(UpdatePermissionGropDto Dto) : IRequest;

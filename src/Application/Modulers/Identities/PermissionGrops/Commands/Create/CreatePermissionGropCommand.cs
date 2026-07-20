using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Commands.Create;

public sealed record CreatePermissionGropCommand(CreatePermissionGropDto Dto) : IRequest<Guid>;

using Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Queries.GetAll;

public sealed record GetPermissionGropsQuery : IRequest<List<PermissionGropDto>>;

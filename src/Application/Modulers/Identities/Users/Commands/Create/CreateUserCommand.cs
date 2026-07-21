using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.Create;

public sealed record CreateUserCommand(CreateUserDto Dto) : IRequest<Guid>;

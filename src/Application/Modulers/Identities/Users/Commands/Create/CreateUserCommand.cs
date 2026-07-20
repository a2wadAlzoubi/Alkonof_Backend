using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.Create;

public record CreateUserCommand(CreateUser CreateUser) : IRequest<Guid>;



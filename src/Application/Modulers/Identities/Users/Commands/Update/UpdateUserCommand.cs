using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.Update;

public record UpdateUserCommand(UserDto UserDto) : IRequest;

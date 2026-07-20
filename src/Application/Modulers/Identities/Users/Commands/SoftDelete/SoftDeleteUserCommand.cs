namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.SoftDelete;

public record SoftDeleteUserCommand(Guid Id) : IRequest;

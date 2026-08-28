namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.SoftDelete;

public record SoftActiveDeleteUserCommand(Guid Id , bool IsDeleted) : IRequest;

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Commands.Remove;

public sealed class RemovePermissionValidator : AbstractValidator<RemovePermissionCommand>
{
    public RemovePermissionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Permission ID cannot be empty.");
    }
}

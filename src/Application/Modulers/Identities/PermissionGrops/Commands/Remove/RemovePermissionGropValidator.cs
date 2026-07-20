namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Commands.Remove;

public sealed class RemovePermissionGropValidator : AbstractValidator<RemovePermissionGropCommand>
{
    public RemovePermissionGropValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Permission group ID cannot be empty.");
    }
}

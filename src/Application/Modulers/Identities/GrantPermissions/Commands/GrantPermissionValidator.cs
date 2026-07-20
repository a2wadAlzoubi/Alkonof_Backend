namespace Alkonof_Backend.Application.Modulers.Identities.GrantPermissions.Commands;

public sealed class GrantPermissionValidator : AbstractValidator<GrantPermissionCommand>
{
    public GrantPermissionValidator()
    {
        RuleFor(x => x.Dto.UserId)
            .NotEmpty().WithMessage("User ID cannot be empty.");

        RuleFor(x => x.Dto.PermissionId)
            .NotEmpty().WithMessage("Permission ID cannot be empty.");
    }
}

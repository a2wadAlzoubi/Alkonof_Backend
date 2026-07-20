namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Commands.Create;

public sealed class CreatePermissionValidator : AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionValidator()
    {
        RuleFor(x => x.Dto.Name)
            .NotEmpty().WithMessage("Permission name cannot be empty.")
            .MaximumLength(50).WithMessage("Permission name cannot exceed 50 characters.");

        RuleFor(x => x.Dto.Description)
            .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");
    }
}

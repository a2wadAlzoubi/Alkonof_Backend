namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Commands.Create;

public sealed class CreatePermissionGropValidator : AbstractValidator<CreatePermissionGropCommand>
{
    public CreatePermissionGropValidator()
    {
        RuleFor(x => x.Dto.Name)
            .NotEmpty().WithMessage("Permission group name cannot be empty.")
            .MaximumLength(50).WithMessage("Permission group name cannot exceed 50 characters.");

        RuleFor(x => x.Dto.Description)
            .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");
    }
}

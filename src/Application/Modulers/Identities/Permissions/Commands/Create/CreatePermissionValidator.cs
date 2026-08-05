namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Commands.Create;

public sealed class CreatePermissionValidator : AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionValidator()
    {
        RuleFor(x => x.Dto.PermissionType)
            .NotEmpty().WithMessage("PermissionType cannot be empty.");
    }
}

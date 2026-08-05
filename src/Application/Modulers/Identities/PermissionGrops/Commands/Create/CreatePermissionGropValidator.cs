namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Commands.Create;

public sealed class CreatePermissionGropValidator : AbstractValidator<CreatePermissionGropCommand>
{
    public CreatePermissionGropValidator()
    {
        RuleFor(x => x.Dto.OperationPermission)
            .NotEmpty().WithMessage("Permission group name cannot be empty.");
    }
}

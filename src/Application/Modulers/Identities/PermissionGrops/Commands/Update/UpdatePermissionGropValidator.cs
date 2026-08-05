namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Commands.Update;

public sealed class UpdatePermissionGropValidator : AbstractValidator<UpdatePermissionGropCommand>
{
    public UpdatePermissionGropValidator()
    {
        RuleFor(x => x.Dto.Id)
            .NotEmpty().WithMessage("Permission group ID cannot be empty.");

        RuleFor(x => x.Dto.OperationPermission)
            .NotEmpty().WithMessage("Permission group name cannot be empty.");
    }
}

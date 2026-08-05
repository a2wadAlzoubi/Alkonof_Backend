namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Commands.Update;

public sealed class UpdatePermissionValidator : AbstractValidator<UpdatePermissionCommand>
{
    public UpdatePermissionValidator()
    {
        RuleFor(x => x.Dto.Id)
            .NotEmpty().WithMessage("Permission ID cannot be empty.");

        RuleFor(x => x.Dto.PermissionType)
            .NotEmpty().WithMessage("PermissionType cannot be empty.");

    }
}

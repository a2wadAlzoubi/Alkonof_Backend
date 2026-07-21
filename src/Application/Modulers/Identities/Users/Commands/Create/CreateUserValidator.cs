using Alkonof_Backend.Application.Modulers.Identities.Users.Commands.Create;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Validators;

public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Dto.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Dto.Email).NotEmpty().EmailAddress().MaximumLength(256);
        RuleFor(x => x.Dto.Password).NotEmpty().MinimumLength(6).MaximumLength(200);
        RuleFor(x => x.Dto.Number).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Dto.Role).IsInEnum();
    }
}

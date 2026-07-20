using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Application.Modulers.Identities.Authentication.Register;

sealed class RegisterValidator : AbstractValidator<RegisterCommand>
{
    public RegisterValidator()
    {
        // Email validators
        _ = RuleFor(c => c.Register.email)
            .NotEmpty().WithMessage("Email Address cannot be empty.")
            .EmailAddress().WithMessage("Please specify a valid email address.")
            .MinimumLength(3).WithMessage("Email Address must be at least 3 characters long.")
            .MaximumLength(320).WithMessage("Email Addresses cannot exceed 320 characters.");

        // Password validator
        _ = RuleFor(c => c.Register.password)
            .NotEmpty().WithMessage("Password cannot be empty.")
            .MinimumLength(8).WithMessage("Passwords must be at least 8 characters long.")
            .MaximumLength(24).WithMessage("Passwords length cannot exceed 24 characters.")
            .Matches("[A-Z]+").WithMessage("Passwords must contain at least one upper-case letter.")
            .Matches("[a-z]+").WithMessage("Passwords must contain at least one lower-case letter.")
            .Matches("[0-9]+").WithMessage("Passwords must contain at least one number.")
            .Matches(@"[\!\?\*\.]+").WithMessage("Passwords must contain at least one symbol: (!? *.).");

        // Confirm password validator
        _ = RuleFor(c => c.Register.confirmPassword)
            .NotEmpty().WithMessage("Confirmation password cannot be empty.")
            .Equal(c => c.Register.password).WithMessage("Password and confirmation must match.");
    }
}

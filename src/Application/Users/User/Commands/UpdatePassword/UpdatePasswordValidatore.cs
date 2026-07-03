using Alkonof_Backend.Domain.Entities;
using Application.Entities.Users.Services;

namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.UpdatePassword;

internal class UpdatePasswordValidatore : AbstractValidator<UpdatePasswordCommand>
{

    //public UpdatePasswordValidatore()
    //{
    //    RuleFor(v => v.PasswordDto.oldPassword.Equals(v.PasswordDto.newPassword) == v.PasswordDto.confirmPassword)
    //        .MaximumLength(200)
    //        .NotEmpty();
    //}
    public static bool CanUpdatePassword( string oldPassword, string newPassword ,string confirmPassword, IPasswordService _passwordService)
    {
        
        var canUpdate = _passwordService.Compare(oldPassword, newPassword)
           && _passwordService.Compare(newPassword, confirmPassword);
        if (!canUpdate)
        {
            
            return false;
        }
        return true;
    }
}

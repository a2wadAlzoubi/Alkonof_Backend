using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Users.ToDoUser.Commands.UpdatePassword;
using Application.Abstractions;
using Application.Entities.Users.Services;

namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.UpdatePasswordForAdmin;

public class UpdatePasswordForAdminCommandHandler : IRequestHandler<UpdatePasswordForAdminCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IPasswordService _passwordService;
    private readonly ICurrentUserProvider _currentUser;

    public UpdatePasswordForAdminCommandHandler(IApplicationDbContext context,
    IPasswordService passwordService, ICurrentUserProvider currentUser)
    {
        _context = context;
        _passwordService = passwordService;
        _currentUser = currentUser;
    }

    public async Task<bool> Handle(UpdatePasswordForAdminCommand request, CancellationToken cancellationToken)
    {

        var user = await _context.User
            .FindAsync([request.PasswordDto.userId], cancellationToken);
        Guard.Against.NotFound(request.PasswordDto.userId, user);

        if (request.PasswordDto.userId != _currentUser.Id && user.Type == Domain.Enums.UserType.admin)
            return false;


        var canUpdate = UpdatePasswordValidatore.CanUpdatePassword(
            request.PasswordDto.oldPassword,
            request.PasswordDto.newPassword,
            request.PasswordDto.confirmPassword,
            _passwordService);

        if (!canUpdate)
        {
            Guard.Against.NotFound(user.Id, user);
            return false;
        }
        var newPassword = _passwordService.Hash(request.PasswordDto.newPassword);
        user.UpdatePassword(newPassword);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

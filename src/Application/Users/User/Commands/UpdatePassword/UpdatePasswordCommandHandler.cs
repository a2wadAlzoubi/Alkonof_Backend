using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Common.Models;
using Alkonof_Backend.Application.Users.ToDoUser.Commands.Update;
using Application.Abstractions;
using Application.Entities.Users.Dtos;
using Application.Entities.Users.Services;

namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.UpdatePassword;

//public class UpdatePasswordCommandHandler(
//    IRepository<User> repository,
//    IPasswordService passwordService,
//    IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserPasswordCommand, bool>
//{
//    public async Task<Result<bool>> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
//    {
//        ArgumentNullException.ThrowIfNull(request);
//        var user = await repository.FirstOrDefaultAsync(new GetByIdSpecification<User>(request.PasswordDto.userId), cancellationToken);
//        if (user is null)
//        {
//            return Result.Failure<bool>(ErrorType.IncorrectCredentials);
//        }

//        var canUpdate = passwordService.Compare(request.PasswordDto.oldPassword, user.Password) 
//            && passwordService.Compare(request.PasswordDto.newPassword, request.PasswordDto.confirmPassword);
//        if (!canUpdate)
//        {
//            return Result.Failure<bool>(ErrorType.IncorrectCredentials);
//        }
//        var newPassword = passwordService.Hash(request.PasswordDto.newPassword);
//        user.UpdatePassword(newPassword);
//        repository.Update(user);
//        await unitOfWork.SaveChangesAsync(cancellationToken);
//        return Result.Success(true);
//    }
//}
public class UpdateUserCommandHandler : IRequestHandler<UpdatePasswordCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IPasswordService _passwordService;
    private readonly ICurrentUserProvider _currentUser;

    public UpdateUserCommandHandler(IApplicationDbContext context,
    IPasswordService passwordService , ICurrentUserProvider currentUser)
    {
        _context = context;
        _passwordService = passwordService;
        _currentUser = currentUser;
    }

    public async Task<bool> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        if(request.PasswordDto.userId != _currentUser.Id)
            return false;

        var user = await _context.User
            .FindAsync([request.PasswordDto.userId], cancellationToken);
        Guard.Against.NotFound(request.PasswordDto.userId, user);

        var canUpdate = UpdatePasswordValidatore.CanUpdatePassword(
            request.PasswordDto.oldPassword,
            request.PasswordDto.newPassword,
            request.PasswordDto.confirmPassword,
            _passwordService);

        if (!canUpdate) {
            Guard.Against.NotFound(user.Id, user);
            return false;
        }
        var newPassword = _passwordService.Hash(request.PasswordDto.newPassword);
        user.UpdatePassword(newPassword , user.Id);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

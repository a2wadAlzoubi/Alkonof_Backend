//using Alkonof_Backend.Application.Common.Interfaces;
//using Alkonof_Backend.Application.Common.Models;
//using Alkonof_Backend.Application.Users.ToDoUser.Commands.Update;
//using Application.Entities.Users.Dtos;
//using Application.Entities.Users.Services;

//namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.UpdatePassword;

////public class UpdatePasswordCommandHandler(
////    IRepository<User> repository,
////    IPasswordService passwordService,
////    IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserPasswordCommand, bool>
////{
////    public async Task<Result<bool>> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
////    {
////        ArgumentNullException.ThrowIfNull(request);
////        var user = await repository.FirstOrDefaultAsync(new GetByIdSpecification<User>(request.PasswordDto.userId), cancellationToken);
////        if (user is null)
////        {
////            return Result.Failure<bool>(ErrorType.IncorrectCredentials);
////        }

////        var canUpdate = passwordService.Compare(request.PasswordDto.oldPassword, user.Password) 
////            && passwordService.Compare(request.PasswordDto.newPassword, request.PasswordDto.confirmPassword);
////        if (!canUpdate)
////        {
////            return Result.Failure<bool>(ErrorType.IncorrectCredentials);
////        }
////        var newPassword = passwordService.Hash(request.PasswordDto.newPassword);
////        user.UpdatePassword(newPassword);
////        repository.Update(user);
////        await unitOfWork.SaveChangesAsync(cancellationToken);
////        return Result.Success(true);
////    }
////}
//public class UpdateUserCommandHandler : IRequestHandler<UpdateUserPasswordCommand , bool>
//{
//    private readonly IApplicationDbContext _context;
//    private readonly IPasswordService _passwordService;

//    public UpdateUserCommandHandler(IApplicationDbContext context,
//    IPasswordService passwordService)
//    {
//        _context = context;
//        _passwordService = passwordService;
//    }

//    public async Task<bool> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
//    {
//        var user = await _context.User
//            .FindAsync([request.PasswordDto.userId], cancellationToken);

//        Guard.Against.NotFound(request.PasswordDto.userId, user);

//        var canUpdate = _passwordService.Compare(request.PasswordDto.oldPassword, user.Password)
//            && _passwordService.Compare(request.PasswordDto.newPassword, request.PasswordDto.confirmPassword);
//        if (!canUpdate)
//        {
//            Guard.Against.NotFound(request.PasswordDto.userId, user);
//            return Result.Failure(ErrorT);
//        }
//        var newPassword = passwordService.Hash(request.PasswordDto.newPassword);
//        user.UpdatePassword(newPassword);
//        user.Update(
//        request.UserDto.Id,
//        request.UserDto.IdentityId,
//        request.UserDto.FullName,
//        request.UserDto.Number,
//        request.UserDto.Email,
//        request.UserDto.Password
//            );

//        await _context.SaveChangesAsync(cancellationToken);
//    }
//}

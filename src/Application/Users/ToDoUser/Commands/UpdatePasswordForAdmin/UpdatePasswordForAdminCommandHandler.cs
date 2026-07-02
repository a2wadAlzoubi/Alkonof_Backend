//using Application.Abstractions;
//using Application.Abstractions.Messaging;
//using Application.Entities.Users.Services;
//using Application.Shared.Specifications;
//using Domain.Abstractions;
//using FainancialGuard.Domain.Entities.Users;

//namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.UpdatePasswordForAdmin
//{
//    public class UpdatePasswordForAdminCommandHandler(
//        IRepository<User> repository,
//        IPasswordService passwordService,
//        IUnitOfWork unitOfWork) : ICommandHandler<UpdatePasswordForAdminCommand, bool>
//    {
//        public async Task<Result<bool>> Handle(UpdatePasswordForAdminCommand request, CancellationToken cancellationToken)
//        {
//            ArgumentNullException.ThrowIfNull(request);
//            var user = await repository.FirstOrDefaultAsync(new GetByIdSpecification<User>(request.PasswordDto.userId),
//                cancellationToken);
//            if (user is null)
//            {
//                return Result.Failure<bool>(ErrorType.IncorrectCredentials);
//            }
//            var canUpdate = passwordService.Compare(request.PasswordDto.newPassword, request.PasswordDto.confirmPassword);
//            if (!canUpdate)
//            {
//                return Result.Failure<bool>(ErrorType.IncorrectCredentials);
//            }

//            var newPassword = passwordService.Hash(request.PasswordDto.newPassword);
//            user.UpdatePassword(newPassword);
//            repository.Update(user);
//            await unitOfWork.SaveChangesAsync(cancellationToken);
//            return Result.Success(true);
//        }
//    }
//}

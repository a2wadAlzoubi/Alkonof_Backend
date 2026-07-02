//using Application.Abstractions;
//using Application.Abstractions.Messaging;
//using Application.Entities.Users.Dtos;
//using Application.Shared.Specifications;
//using Domain.Abstractions;
//using FainancialGuard.Domain.Entities.Users;
//using Mapster;

//namespace Alkonof_Backend.Application.Users.ToDoUser.Queries.GetById;
//internal class GetUserByIdCommandHandler(IRepository<User> repository)
//: ICommandHandler<GetUserByIdCommand, UserDto>
//{
//    public async Task<Result<UserDto>> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
//    {
//        var users = await repository.GetAllWithRelated(new GetByIdSpecification<User>(request.userId),
//            cancellationToken);
//        if (users is null) return Result.Failure<UserDto>(ErrorType.IncorrectCredentials);
//        var user = users.FirstOrDefault();
//        if (user is null) return Result.Failure<UserDto>(ErrorType.IncorrectCredentials);
//        /*
//            var userResponse = new UserDto
//            {
//                Id = user.Id,
//                Name = user.Name,
//                Email = user.Email,
//                Password = user.Password,
//                UserRole = user.UserRole
//            };
//         */
//        var userResponse = user.Adapt<UserDto>();
//        return Result.Success(userResponse);
//    }
//}

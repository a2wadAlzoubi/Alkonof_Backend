//using Alkonof_Backend.Application.Common.Interfaces;
//using Alkonof_Backend.Application.TodoLists.Queries.GetTodos;
//using Application.Abstractions;
//using Application.Abstractions.Messaging;
//using Application.Entities.Users.Dtos;
//using Application.Entities.Users.Specifications;
//using Application.Shared.Specifications;
//using Domain.Abstractions;
//using FainancialGuard.Domain.Entities.Users;
//using Mapster;

//namespace Alkonof_Backend.Application.Users.ToDoUser.Queries.GetByEmail;
//internal class GetUserByEmailCommandHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetUserByEmailCommand, UserDto>
//{
//    public async Task<Result<UserDto>> Handle(GetUserByEmailCommand request, CancellationToken cancellationToken)
//    {
//        var users = await repository.GetAllWithRelated(new GetUserByEmail(request.email),
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

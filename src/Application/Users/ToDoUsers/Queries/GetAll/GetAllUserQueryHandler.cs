//using Application.Abstractions;
//using Application.Abstractions.Messaging;
//using Application.Entities.Users.Dtos;
//using Domain.Abstractions;
//using FainancialGuard.Domain.Entities.Users;

//namespace Alkonof_Backend.Application.Users.ToDoUsers.Queries.GetAll;

//internal sealed class GetAllUserQueryHandler(IRepository<User> repository)
//    : IQueryHandler<GetAllUserQuery, PaginatedList<UserDto>>
//{
//    public async Task<Result<PaginatedList<UserDto>>> Handle(GetAllUserQuery request,
//        CancellationToken cancellationToken)
//    {
//        var users = await repository.GetSpecifiedPaginatedList(request, cancellationToken);
//        return users;
//    }
//}

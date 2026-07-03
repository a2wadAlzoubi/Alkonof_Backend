using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Common.Models;
using Alkonof_Backend.Application.Common.Security;
using Alkonof_Backend.Application.TodoLists.Queries.GetTodos;
using Alkonof_Backend.Domain.Enums;
using Alkonof_Backend.Domain.ValueObjects;
using Application.Entities.Users.Dtos;
using Mapster;
using Mapster.Utils;

namespace Alkonof_Backend.Application.Users.ToDoUser.Queries.GetByEmail;

[Authorize]
public record GetUserByEmailQuery(string Email): IRequest<UserDto>;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
{
    private readonly IApplicationDbContext _context;

    public GetUserByEmailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.User.FindAsync([request.Email] , cancellationToken);
        Guard.Against.NotFound(request.Email, user);

        var userResponse = user.Adapt<UserDto>();
        return userResponse;

    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetAll;

internal sealed class GetUsersQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetUsersQuery, List<UserDto>>
{
    public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await context.User
            .Where(u => !u.IsDeleted)
            .Select(u => new UserDto(
                u.Id,
                u.Name,
                u.Number,
                u.Email,
                u.Role,
                u.IsDeleted,
                u.PermissionId
            ))
            .ToListAsync(cancellationToken);

        return users;
    }
}

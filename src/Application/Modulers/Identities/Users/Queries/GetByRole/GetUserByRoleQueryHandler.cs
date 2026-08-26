using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetByRole;

internal sealed class GetUserByRoleQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetUserByRoleQuery, List<UserDto>>
{
    public async Task<List<UserDto>> Handle(GetUserByRoleQuery request, CancellationToken cancellationToken)
    {
        var users = await context.User
            .Where(u => u.Role == request.Role && !u.IsDeleted)
            .Select(u => new UserDto(
                u.Id,
                u.Name,
                u.Number,
                u.Email,
                u.Role,
                u.IsDeleted,
                u.Specialization,
                u.PermissionId
            ))
            .ToListAsync();

        if (users is null)
        {
            throw new NotFoundException(nameof(User), request.Role.ToString());
        }

        return users;
    }
}

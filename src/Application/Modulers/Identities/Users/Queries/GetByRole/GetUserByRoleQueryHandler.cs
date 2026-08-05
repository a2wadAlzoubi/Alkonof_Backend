using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetByRole;

internal sealed class GetUserByRoleQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetUserByRoleQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByRoleQuery request, CancellationToken cancellationToken)
    {
        var user = await context.User
            .Where(u => u.Role == request.Role && !u.IsDeleted)
            .Select(u => new UserDto(
                u.Id,
                u.Name,
                u.Number,
                u.Email,
                u.Role,
                u.IsDeleted,
                u.PermissionId
            ))
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.Role.ToString());
        }

        return user;
    }
}

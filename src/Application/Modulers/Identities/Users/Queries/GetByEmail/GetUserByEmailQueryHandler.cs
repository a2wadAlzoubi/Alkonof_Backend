using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetByEmail;

internal sealed class GetUserByEmailQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetUserByEmailQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await context.User
            .Where(u => u.Email == request.Email && !u.IsDeleted)
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
            throw new NotFoundException(nameof(User), request.Email);
        }

        return user;
    }
}

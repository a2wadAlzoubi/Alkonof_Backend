using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetById;

internal sealed class GetUserByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await context.User
            .Where(u => u.Id == request.Id )
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
            throw new NotFoundException(nameof(User), request.Id.ToString());
        }

        return user;
    }
}

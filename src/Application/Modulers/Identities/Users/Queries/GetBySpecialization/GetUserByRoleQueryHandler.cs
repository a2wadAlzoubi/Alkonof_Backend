using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetBySpecialization;

internal sealed class GetUserBySpecializationQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetUserBySpecializationQuery, List<UserDto>>
{
    public async Task<List<UserDto>> Handle(GetUserBySpecializationQuery request, CancellationToken cancellationToken)
    {
        var users = await context.User
            .Where(u => u.Specialization == request.Specialization && !u.IsDeleted)
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
            throw new NotFoundException(nameof(User), request.Specialization.ToString());
        }

        return users;
    }
}

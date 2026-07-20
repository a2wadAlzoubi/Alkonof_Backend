using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;
using Mapster;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IApplicationDbContext _context;

    public GetUserByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.User.FindAsync([request.UserId], cancellationToken);
        Guard.Against.NotFound(request.UserId, user);

        var userResponse = user.Adapt<UserDto>();
        return userResponse;

    }
}

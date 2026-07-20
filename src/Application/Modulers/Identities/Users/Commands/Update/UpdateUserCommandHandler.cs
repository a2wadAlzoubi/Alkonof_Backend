using Alkonof_Backend.Application.Common.Interfaces;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.Update;


public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.User
            .FindAsync([request.UserDto.Id], cancellationToken);

        Guard.Against.NotFound(request.UserDto.Id, user);

        user.Update(
        request.UserDto.Name,
        request.UserDto.Number,
        request.UserDto.Email,
        request.UserDto.Password,
        request.UserDto.Role,
        request.UserDto.IsDeleted,
        request.UserDto.PermissionId
            );

        await _context.SaveChangesAsync(cancellationToken);
    }
}

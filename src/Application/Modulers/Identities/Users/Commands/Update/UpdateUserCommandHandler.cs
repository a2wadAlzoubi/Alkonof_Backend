using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Application.Abstractions;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.Update;


public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IPasswordService passwordService;

    public UpdateUserCommandHandler(IApplicationDbContext context , IPasswordService passwordService)
    {
        _context = context;
        this.passwordService = passwordService;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        var user = await _context.User
            .FindAsync([request.UserDto.Id], cancellationToken);

        Guard.Against.NotFound(request.UserDto.Id, user);


        if (user.Role != UserRole.Admin) { throw new InvalidOperationException("Current user is not authenticated."); }

        var hashPassword = passwordService.Hash(request.UserDto.Password);

        user.Update(
        request.UserDto.Name,
        request.UserDto.Number,
        request.UserDto.Email,
        hashPassword,
        request.UserDto.Role,
        request.UserDto.IsDeleted,
        request.UserDto.PermissionId
            );

        await _context.SaveChangesAsync(cancellationToken);
    }
}

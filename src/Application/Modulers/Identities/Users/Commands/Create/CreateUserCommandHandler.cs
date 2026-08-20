using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Users.Commands.Create;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Microsoft.AspNetCore.Authorization;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Handlers;

[Authorize]
internal sealed class CreateUserCommandHandler(IApplicationDbContext context, IPasswordService passwordService)
    : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var existingUser = await context.User.FirstOrDefaultAsync(u => u.Email == request.Dto.Email, cancellationToken);
        if (existingUser is not null)
        {
            throw new InvalidOperationException("User with this email already exists.");
        }

        var hashedPassword = passwordService.Hash(request.Dto.Password);

        var user = User.Create(
            request.Dto.Name,
            request.Dto.Number,
            request.Dto.Email,
            hashedPassword,
            request.Dto.Role,
            false, // IsDeleted
            request.Dto.PermissionId,
            request.Dto.Specialization
        );

        context.User.Add(user);
        await context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Users.Services;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.UpdatePassword;

internal sealed class UpdatePasswordCommandHandler(
    IApplicationDbContext context,
    IPasswordService passwordService)
    : IRequestHandler<UpdatePasswordCommand>
{
    public async Task Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await context.User
            .FirstOrDefaultAsync(u => u.Id == request.Dto.userId, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(User), request.Dto.userId.ToString());
        }

        if (!passwordService.Compare(request.Dto.oldPassword, user.Password))
        {
            throw new InvalidOperationException("Invalid old password.");
        }
        if (!passwordService.CompareNH(request.Dto.newPassword, request.Dto.confirmPassword))
        {
            throw new InvalidOperationException("Invalid Confirming password.");
        }

        var newPasswordHash = passwordService.Hash(request.Dto.newPassword);
        user.UpdatePassword(newPasswordHash , user.Id);

        await context.SaveChangesAsync(cancellationToken);
    }
}

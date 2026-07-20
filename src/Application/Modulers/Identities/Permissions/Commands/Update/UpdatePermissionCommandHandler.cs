using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.Permissions.Commands.Update;

internal sealed class UpdatePermissionCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdatePermissionCommand>
{
    public async Task Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = await context.Permission
            .FindAsync(new object[] { request.Dto.Id }, cancellationToken);

        if (permission is null)
        {
            throw new NotFoundException(nameof(Permission), request.Dto.Id.ToString());
        }

        permission.Update(request.Dto.Name, request.Dto.Description);

        await context.SaveChangesAsync(cancellationToken);
    }
}

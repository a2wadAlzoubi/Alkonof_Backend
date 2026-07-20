using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Application.Modulers.Identities.PermissionGrops.Commands.Update;

internal sealed class UpdatePermissionGropCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdatePermissionGropCommand>
{
    public async Task Handle(UpdatePermissionGropCommand request, CancellationToken cancellationToken)
    {
        var permissionGrop = await context.PermissionGrop
            .FindAsync(new object[] { request.Dto.Id }, cancellationToken);

        if (permissionGrop is null)
        {
            throw new NotFoundException(nameof(PermissionGrop), request.Dto.Id.ToString());
        }

        permissionGrop.Update(request.Dto.Name, request.Dto.Description, request.Dto.PermissionId);

        await context.SaveChangesAsync(cancellationToken);
    }
}

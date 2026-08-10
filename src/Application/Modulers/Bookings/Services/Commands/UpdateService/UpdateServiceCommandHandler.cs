using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Exceptions;
using Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Commands.UpdateService;

internal sealed class UpdateServiceCommandHandler(IApplicationDbContext context , ICurrentUserProvider currentUser)
    : IRequestHandler<UpdateServiceCommand>
{
    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        if (currentUser.Role != UserRole.Admin) { throw new InvalidOperationException("Current user is not authenticated."); }
        var service = await context.Service
            .FirstOrDefaultAsync(s => s.Id == request.Dto.Id, cancellationToken);

        if (service is null)
        {
            throw new NotFoundException(nameof(Service), request.Dto.Id.ToString());
        }

        service.Update(
            request.Dto.ServiceName,
            request.Dto.Description,
            request.Dto.ServiceType
        );

        await context.SaveChangesAsync(cancellationToken);
    }
}

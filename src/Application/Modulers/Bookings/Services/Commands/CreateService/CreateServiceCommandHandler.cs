using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetById;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Commands.CreateService;

internal sealed class CreateServiceCommandHandler(IApplicationDbContext context , ICurrentUserProvider currentUser)
    : IRequestHandler<CreateServiceCommand, Guid>
{
    public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        if(currentUser.Role != UserRole.Admin) { throw new InvalidOperationException("Current user is not authenticated."); }

        var service = Service.Create(
            request.Dto.ServiceName,
            request.Dto.Description,
            request.Dto.ServiceType
        );

        context.Service.Add(service);
        await context.SaveChangesAsync(cancellationToken);

        return service.Id;
    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Bookings;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Commands.CreateService;

internal sealed class CreateServiceCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateServiceCommand, Guid>
{
    public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = Service.Create(
            request.Dto.ServiceName,
            request.Dto.Description,
            request.Dto.ServiceType
        );

        await context.Service.AddAsync(service, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return service.Id;
    }
}

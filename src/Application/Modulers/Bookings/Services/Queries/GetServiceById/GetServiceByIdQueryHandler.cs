using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Services.Dtos;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Queries.GetServiceById;

internal sealed class GetServiceByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetServiceByIdQuery, ServiceDto?>
{
    public async Task<ServiceDto?> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var service = await context.Service
            .AsNoTracking()
            .Where(s => s.Id == request.ServiceId)
            .Select(s => new ServiceDto
            {
                Id = s.Id,
                ServiceName = s.ServiceName,
                Description = s.Description,
                ServiceType = s.ServiceType,
            })
            .FirstOrDefaultAsync(cancellationToken);

        return service;
    }
}

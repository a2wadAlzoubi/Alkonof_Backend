using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Services.Dtos;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Queries.GetServices;

internal sealed class GetServicesQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetServicesQuery, List<ServiceDto>>
{
    public async Task<List<ServiceDto>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
    {
        var services = await context.Service
            .AsNoTracking()
            .Select(s => new ServiceDto
            {
                Id = s.Id,
                ServiceName = s.ServiceName,
                Description = s.Description,
                ServiceType = s.ServiceType,
            })
            .ToListAsync(cancellationToken);

        return services;
    }
}

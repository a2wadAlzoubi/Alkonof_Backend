using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Services.Dtos;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Queries.GetServiceByName;

internal sealed class GetServiceByNameQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetServiceByNameQuery, List<ServiceDto>>
{
    public async Task<List<ServiceDto>> Handle(GetServiceByNameQuery request, CancellationToken cancellationToken)
    {
        var services = await context.Service
            .AsNoTracking()
            .Where(s => s.ServiceName.Contains(request.ServiceName))
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

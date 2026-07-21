using Alkonof_Backend.Application.Modulers.Bookings.Services.Dtos;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Queries.GetServiceByName;

public sealed record GetServiceByNameQuery(string ServiceName) : IRequest<List<ServiceDto>>;

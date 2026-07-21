using Alkonof_Backend.Application.Modulers.Bookings.Services.Dtos;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Queries.GetServices;

public sealed record GetServicesQuery : IRequest<List<ServiceDto>>;

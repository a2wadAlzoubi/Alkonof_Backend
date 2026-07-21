using Alkonof_Backend.Application.Modulers.Bookings.Services.Dtos;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Queries.GetServiceById;

public sealed record GetServiceByIdQuery(Guid ServiceId) : IRequest<ServiceDto?>;

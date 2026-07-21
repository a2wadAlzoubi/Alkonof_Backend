using Alkonof_Backend.Application.Modulers.Bookings.Services.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Commands.CreateService;

public sealed record CreateServiceCommand(CreateServiceDto Dto) : IRequest<Guid>;

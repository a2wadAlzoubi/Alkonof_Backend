using Alkonof_Backend.Application.Modulers.Bookings.Services.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Commands.UpdateService;

public sealed record UpdateServiceCommand(ServiceDto Dto) : IRequest;

using MediatR;

namespace Alkonof_Backend.Application.Modulers.Bookings.Services.Commands.RemoveService;

public sealed record RemoveServiceCommand(Guid ServiceId) : IRequest;

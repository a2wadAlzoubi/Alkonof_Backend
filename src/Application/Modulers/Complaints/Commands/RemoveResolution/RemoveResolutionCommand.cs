using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.RemoveResolution;

public sealed record RemoveResolutionCommand(Guid Id) : IRequest;

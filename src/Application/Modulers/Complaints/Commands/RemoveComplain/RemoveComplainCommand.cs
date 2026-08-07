using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.RemoveComplain;

public sealed record RemoveComplainCommand(Guid Id) : IRequest;

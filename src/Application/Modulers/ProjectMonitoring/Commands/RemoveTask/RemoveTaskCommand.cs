using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.RemoveTask;

public sealed record RemoveTaskCommand(Guid Id) : IRequest;

using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.RemoveStage;

public sealed record RemoveStageCommand(Guid Id) : IRequest;

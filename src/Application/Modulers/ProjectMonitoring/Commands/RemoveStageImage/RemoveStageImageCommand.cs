using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.RemoveStageImage;

public sealed record RemoveStageImageCommand(Guid Id) : IRequest;

using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateStage;

public sealed record UpdateStageCommand(UpdateStageDto UpdateStageDto) : IRequest;

using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateStage;

public sealed record CreateStageCommand(CreateStageDto CreateStageDto) : IRequest<Guid>;

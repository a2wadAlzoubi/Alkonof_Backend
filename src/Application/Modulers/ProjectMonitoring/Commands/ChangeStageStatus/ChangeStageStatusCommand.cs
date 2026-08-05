using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.ChangeStageStatus;

public sealed record ChangeStageStatusCommand(ChangeStageStatusDto ChangeStageStatusDto) : IRequest;

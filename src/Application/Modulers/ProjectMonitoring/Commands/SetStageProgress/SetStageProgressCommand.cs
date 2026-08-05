using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.SetStageProgress;

public sealed record SetStageProgressCommand(SetStageProgressDto SetStageProgressDto) : IRequest;

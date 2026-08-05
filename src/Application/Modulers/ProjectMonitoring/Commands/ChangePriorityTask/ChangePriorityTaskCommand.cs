using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.ChangePriorityTask;

public sealed record ChangePriorityTaskCommand(ChangePriorityTaskDto ChangePriorityTaskDto) : IRequest;

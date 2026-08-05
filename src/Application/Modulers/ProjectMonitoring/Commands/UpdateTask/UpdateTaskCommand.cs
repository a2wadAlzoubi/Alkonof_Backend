using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateTask;

public sealed record UpdateTaskCommand(UpdateTaskDto UpdateTaskDto) : IRequest;

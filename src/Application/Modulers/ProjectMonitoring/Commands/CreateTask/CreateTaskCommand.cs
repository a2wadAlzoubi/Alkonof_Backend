using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateTask;

public sealed record CreateTaskCommand(CreateTaskDto CreateTaskDto) : IRequest<Guid>;

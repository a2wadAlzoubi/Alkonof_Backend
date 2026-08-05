using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetTasksById;

public sealed record GetTasksByIdQuery(Guid Id) : IRequest<TaskDto?>;

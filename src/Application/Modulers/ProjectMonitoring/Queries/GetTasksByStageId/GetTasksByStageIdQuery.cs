using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetTasksByStageId;

public sealed record GetTasksByStageIdQuery(Guid StageId) : IRequest<List<TaskDto>>;

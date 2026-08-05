using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;
using Alkonof_Backend.Domain.Enums;
using MediatR;
using System.Collections.Generic;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStagesByPriorityId;

public sealed record GetStagesByPriorityIdQuery(PriorityLevel Priority) : IRequest<List<TaskDto>>;

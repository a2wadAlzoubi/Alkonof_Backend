using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStagesByProjectId;

public sealed record GetStagesByProjectIdQuery(Guid ProjectId) : IRequest<List<StageDto>>;

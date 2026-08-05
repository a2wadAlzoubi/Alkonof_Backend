using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStageImagesByStageId;

public sealed record GetStageImagesByStageIdQuery(Guid StageId) : IRequest<List<StageImageDto>>;

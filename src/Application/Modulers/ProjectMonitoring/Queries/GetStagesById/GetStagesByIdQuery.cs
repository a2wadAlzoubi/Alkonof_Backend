using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStagesById;

public sealed record GetStagesByIdQuery(Guid Id) : IRequest<StageDto?>;

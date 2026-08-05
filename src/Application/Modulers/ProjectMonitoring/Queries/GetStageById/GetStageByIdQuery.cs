using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStageById;

public sealed record GetStageByIdQuery(Guid Id) : IRequest<StageDto?>;

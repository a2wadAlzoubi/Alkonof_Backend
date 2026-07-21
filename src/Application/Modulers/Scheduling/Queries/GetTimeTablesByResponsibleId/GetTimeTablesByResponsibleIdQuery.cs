using Alkonof_Backend.Application.Modulers.Scheduling.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Queries.GetTimeTablesByResponsibleId;

public sealed record GetTimeTablesByResponsibleIdQuery(Guid ResponsibleId) : IRequest<List<TimeTableDto>>;

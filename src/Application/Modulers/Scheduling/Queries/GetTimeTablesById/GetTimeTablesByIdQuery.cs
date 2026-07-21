using Alkonof_Backend.Application.Modulers.Scheduling.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Queries.GetTimeTablesById;

public sealed record GetTimeTablesByIdQuery(Guid Id) : IRequest<List<TimeTableDto>>;

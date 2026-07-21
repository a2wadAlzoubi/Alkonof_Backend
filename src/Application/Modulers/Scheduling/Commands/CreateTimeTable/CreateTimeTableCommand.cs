using Alkonof_Backend.Application.Modulers.Scheduling.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Commands.CreateTimeTable;

public sealed record CreateTimeTableCommand(List<TimeTableDto> Dtos, Guid RequesterId) : IRequest<List<Guid>>;

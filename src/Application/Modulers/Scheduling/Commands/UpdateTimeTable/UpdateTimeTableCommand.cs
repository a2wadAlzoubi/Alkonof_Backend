using Alkonof_Backend.Application.Modulers.Scheduling.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Commands.UpdateTimeTable;

public sealed record UpdateTimeTableCommand(TimeTableDto Dto, Guid RequesterId) : IRequest;

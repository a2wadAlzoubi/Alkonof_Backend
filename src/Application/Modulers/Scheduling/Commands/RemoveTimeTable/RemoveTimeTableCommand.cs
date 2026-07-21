using MediatR;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Commands.RemoveTimeTable;

public sealed record RemoveTimeTableCommand(Guid TimeTableId, Guid RequesterId) : IRequest;

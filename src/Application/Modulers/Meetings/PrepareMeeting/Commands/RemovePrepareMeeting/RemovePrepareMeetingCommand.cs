using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Commands.RemovePrepareMeeting;

public sealed record RemovePrepareMeetingCommand(Guid Id) : IRequest;

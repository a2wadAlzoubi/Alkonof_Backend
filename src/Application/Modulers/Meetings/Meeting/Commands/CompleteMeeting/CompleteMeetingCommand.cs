using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.CompleteMeeting;

public sealed record CompleteMeetingCommand(Guid MeetingId) : IRequest;

using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.CancellMeeting;

public sealed record CancellMeetingCommand(Guid MeetingId) : IRequest;

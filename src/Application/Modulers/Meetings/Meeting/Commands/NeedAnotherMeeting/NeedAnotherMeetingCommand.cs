using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.NeedAnotherMeeting;

public sealed record NeedAnotherMeetingCommand(Guid MeetingId) : IRequest;

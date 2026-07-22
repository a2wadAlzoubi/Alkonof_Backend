using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.RejectedMeeting;

public sealed record RejectedMeetingCommand(Guid MeetingId) : IRequest;

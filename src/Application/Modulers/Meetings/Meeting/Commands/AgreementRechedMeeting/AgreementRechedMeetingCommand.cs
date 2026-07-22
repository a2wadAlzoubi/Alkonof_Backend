using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.AgreementRechedMeeting;

public sealed record AgreementRechedMeetingCommand(Guid MeetingId) : IRequest;

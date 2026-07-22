using Alkonof_Backend.Domain.Entities.Meetings.Enum;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.SetUserStatusMeeting;

public sealed record SetUserStatusMeetingCommand(Guid MeetingId, Guid UserId, MeetingUserStatus Status, bool IsCustomer) : IRequest;

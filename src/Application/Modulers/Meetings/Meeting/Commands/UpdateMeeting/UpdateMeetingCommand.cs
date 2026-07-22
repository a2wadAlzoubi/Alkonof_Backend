using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.UpdateMeeting;

public sealed record UpdateMeetingCommand(Guid Id, MeetingDto Dto) : IRequest;

using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.CreateMeeting;

public sealed record CreateMeetingCommand(CreateMeetingDto Dto) : IRequest<Guid>;

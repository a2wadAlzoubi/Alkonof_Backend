using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetNeededAnotherMeetings;

public sealed record GetNeededAnotherMeetingsQuery : IRequest<List<MeetingDto>>;

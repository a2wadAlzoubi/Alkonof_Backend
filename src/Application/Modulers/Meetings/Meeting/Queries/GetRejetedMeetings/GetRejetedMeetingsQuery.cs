using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetRejetedMeetings;

public sealed record GetRejetedMeetingsQuery : IRequest<List<MeetingDto>>;

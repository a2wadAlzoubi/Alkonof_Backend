using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using Domain.DateHelper;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetMeetings;

public sealed record GetMeetingsQuery(TimeRange Range = TimeRange.None) : IRequest<List<MeetingDto>>;

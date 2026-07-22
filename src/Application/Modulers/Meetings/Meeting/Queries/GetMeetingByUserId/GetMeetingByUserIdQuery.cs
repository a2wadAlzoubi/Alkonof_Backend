using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using Alkonof_Backend.Domain.Entities.Meetings.Enum;
using Domain.DateHelper;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetMeetingByUserId;

public sealed record GetMeetingByUserIdQuery(Guid UserId ,TimeRange Range = TimeRange.None) : IRequest<List<MeetingDto>>;

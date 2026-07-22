using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using Alkonof_Backend.Domain.Entities.Meetings.Enum;
using Domain.DateHelper;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetMeetingByUserIdStatusDate;

public sealed record GetMeetingByUserIdStatusDateQuery(Guid UserId ,MeetingStatus Status = MeetingStatus.Completed , TimeRange Range = TimeRange.None) : IRequest<List<MeetingDto>>;

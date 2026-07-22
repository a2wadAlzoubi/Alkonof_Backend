using Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Queries.GetPrepareMeetingByMeetingId;

public sealed record GetPrepareMeetingByMeetingIdQuery(Guid MeetingId) : IRequest<List<PrepareMeetingDto>>;

using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetMeetingById;

public sealed record GetMeetingByIdQuery(Guid Id) : IRequest<MeetingDto>;

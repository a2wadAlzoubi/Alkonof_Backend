using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetAgreementRechedMeetings;

public sealed record GetAgreementRechedMeetingsQuery : IRequest<List<MeetingDto>>;

using Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Queries.GetPrepareMeetings;

public sealed record GetPrepareMeetingsQuery : IRequest<List<PrepareMeetingDto>>;

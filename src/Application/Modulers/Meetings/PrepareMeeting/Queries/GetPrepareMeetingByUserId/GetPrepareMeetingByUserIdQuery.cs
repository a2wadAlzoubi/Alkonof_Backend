using Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Queries.GetPrepareMeetingByUserId;

public sealed record GetPrepareMeetingByUserIdQuery(Guid UserId) : IRequest<List<PrepareMeetingDto>>;

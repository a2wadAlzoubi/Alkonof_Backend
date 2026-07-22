using Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Queries.GetPrepareMeetingById;

public sealed record GetPrepareMeetingByIdQuery(Guid Id) : IRequest<PrepareMeetingDto>;

using Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Queries.GetPrepareMeetingByBookingId;

public sealed record GetPrepareMeetingByBookingIdQuery(Guid BookingId) : IRequest<List<PrepareMeetingDto>>;

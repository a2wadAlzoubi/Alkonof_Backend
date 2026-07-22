using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Queries.GetPrepareMeetingByBookingId;

internal sealed class GetPrepareMeetingByBookingIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetPrepareMeetingByBookingIdQuery, List<PrepareMeetingDto>>
{
    public async Task<List<PrepareMeetingDto>> Handle(GetPrepareMeetingByBookingIdQuery request, CancellationToken cancellationToken)
    {
        var prepareMeetings = await context.PrepareMeeting
            .AsNoTracking()
            .Where(pm => pm.BookingId == request.BookingId)
            .Select(pm => new PrepareMeetingDto
            {
                Id = pm.Id,
                Location = pm.Location,
                StartedAt = pm.StartedAt,
                EndedAt = pm.EndedAt,
                BookingId = pm.BookingId,
                MeetingId = pm.MeetingId
            })
            .ToListAsync(cancellationToken);

        return prepareMeetings;
    }
}

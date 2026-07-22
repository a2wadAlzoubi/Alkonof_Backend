using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Queries.GetPrepareMeetingByUserId;

internal sealed class GetPrepareMeetingByUserIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetPrepareMeetingByUserIdQuery, List<PrepareMeetingDto>>
{
    public async Task<List<PrepareMeetingDto>> Handle(GetPrepareMeetingByUserIdQuery request, CancellationToken cancellationToken)
    {
        var prepareMeetings = await context.PrepareMeeting
            .AsNoTracking()
            .Include(pm => pm.Booking)
            .Where(pm => pm.Booking != null && (pm.Booking.CustomerId == request.UserId || pm.Booking.ResponsibleId == request.UserId))
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

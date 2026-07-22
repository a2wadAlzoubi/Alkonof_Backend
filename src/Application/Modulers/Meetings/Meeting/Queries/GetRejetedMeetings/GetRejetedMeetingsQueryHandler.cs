using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using Alkonof_Backend.Domain.Entities.Meetings.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetRejetedMeetings;

internal sealed class GetRejetedMeetingsQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetRejetedMeetingsQuery, List<MeetingDto>>
{
    public async Task<List<MeetingDto>> Handle(GetRejetedMeetingsQuery request, CancellationToken cancellationToken)
    {
        var meetings = await context.Meeting
            .AsNoTracking()
            .Where(m => m.OutCome == MeetingOutCome.Rejected)
            .Select(m => new MeetingDto
            {
                Id = m.Id,
                Title = m.Title,
                Content = m.Content,
                OutCome = m.OutCome,
                MeetingNumber = m.MeetingNumber,
                Status = m.Status,
                ResponsibleStatus = m.ResponsibleStatus,
                CustomerStatus = m.CustomerStatus
            })
            .ToListAsync(cancellationToken);

        return meetings;
    }
}

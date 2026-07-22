using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using Alkonof_Backend.Domain.Entities.Meetings.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetAgreementRechedMeetings;

internal sealed class GetAgreementRechedMeetingsQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetAgreementRechedMeetingsQuery, List<MeetingDto>>
{
    public async Task<List<MeetingDto>> Handle(GetAgreementRechedMeetingsQuery request, CancellationToken cancellationToken)
    {
        var meetings = await context.Meeting
            .AsNoTracking()
            .Where(m => m.OutCome == MeetingOutCome.AgreementReched)
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

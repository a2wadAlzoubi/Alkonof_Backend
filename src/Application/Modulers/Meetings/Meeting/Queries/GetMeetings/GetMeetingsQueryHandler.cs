using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using Domain.DateHelper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetMeetings;

internal sealed class GetMeetingsQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetMeetingsQuery, List<MeetingDto>>
{
    public async Task<List<MeetingDto>> Handle(GetMeetingsQuery request, CancellationToken cancellationToken)
    {
        var meetings = await context.Meeting
           .AsNoTracking()
           .Include(m => m.PrepareMeeting!)
           .ThenInclude(pm => pm.Booking!)
           .ThenInclude(b => b.Responsible)
           .Include(m => m.PrepareMeeting!)
           .ThenInclude(pm => pm.Booking!)
           .ThenInclude(b => b.Customer!)
           .Where(m => m.Created >= DateRangeHelper.GetFromDate(request.Range))
           .Select(m => new MeetingDto
           {
               Id = m.Id,
               Title = m.Title,
               Content = m.Content,
               OutCome = m.OutCome,
               MeetingNumber = m.MeetingNumber,
               Status = m.Status,
               ResponsibleStatus = m.ResponsibleStatus,
               CustomerStatus = m.CustomerStatus,
               ResponsibleName = m.PrepareMeeting!.Booking!.Responsible!.Name,
               CustomerName = m.PrepareMeeting.Booking.Customer!.Name
           })
           .ToListAsync(cancellationToken);

        return meetings;
    }
}

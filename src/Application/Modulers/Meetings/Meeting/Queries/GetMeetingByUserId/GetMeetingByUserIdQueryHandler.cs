using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using Alkonof_Backend.Domain.Entities.Meetings.Enum;
using Domain.DateHelper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetMeetingByUserId;


internal sealed class GetMeetingByUserIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetMeetingByUserIdQuery, List<MeetingDto>>
{
    public async Task<List<MeetingDto>> Handle(GetMeetingByUserIdQuery request, CancellationToken cancellationToken)
    {
        
        var meetings = await context.Meeting
            .AsNoTracking()
            .Include(m => m.PrepareMeeting!)
            .ThenInclude(pm => pm.Booking!)
            .ThenInclude(b => b.Responsible)
            .Include(m => m.PrepareMeeting!)
            .ThenInclude(pm => pm.Booking!)
            .ThenInclude(b => b.Customer!)
            .Where(m => m.PrepareMeeting!.Booking != null 
            && (m.PrepareMeeting!.Booking.CustomerId == request.UserId || m.PrepareMeeting!.Booking.ResponsibleId == request.UserId))
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

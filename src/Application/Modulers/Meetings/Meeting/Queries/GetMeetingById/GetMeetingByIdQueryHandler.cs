using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Queries.GetMeetingById;

internal sealed class GetMeetingByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetMeetingByIdQuery, MeetingDto>
{
    public async Task<MeetingDto> Handle(GetMeetingByIdQuery request, CancellationToken cancellationToken)
    {
        var meeting = await context.Meeting
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (meeting is null)
        {
            throw new NotFoundException(nameof(Meeting), request.Id.ToString());
        }

        return new MeetingDto
        {
            Id = meeting.Id,
            Title = meeting.Title,
            Content = meeting.Content,
            OutCome = meeting.OutCome,
            MeetingNumber = meeting.MeetingNumber,
            Status = meeting.Status,
            ResponsibleStatus = meeting.ResponsibleStatus,
            CustomerStatus = meeting.CustomerStatus
        };
    }
}

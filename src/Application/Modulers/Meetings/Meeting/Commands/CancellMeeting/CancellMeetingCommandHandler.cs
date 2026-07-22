using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.CancellMeeting;

internal sealed class CancellMeetingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CancellMeetingCommand>
{
    public async Task Handle(CancellMeetingCommand request, CancellationToken cancellationToken)
    {
        var meeting = await context.Meeting
            .FirstOrDefaultAsync(m => m.Id == request.MeetingId, cancellationToken);

        if (meeting is null)
        {
            throw new NotFoundException(nameof(Meeting), request.MeetingId.ToString());
        }

        meeting.CancellMeeting(request.MeetingId);

        await context.SaveChangesAsync(cancellationToken);
    }
}

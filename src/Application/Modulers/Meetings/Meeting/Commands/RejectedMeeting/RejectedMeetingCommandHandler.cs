using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.RejectedMeeting;

internal sealed class RejectedMeetingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<RejectedMeetingCommand>
{
    public async Task Handle(RejectedMeetingCommand request, CancellationToken cancellationToken)
    {
        var meeting = await context.Meeting
            .FirstOrDefaultAsync(m => m.Id == request.MeetingId, cancellationToken);

        if (meeting is null)
        {
            throw new NotFoundException(nameof(Meeting), request.MeetingId.ToString());
        }

        meeting.RejectedMeeting(request.MeetingId , meeting.MeetingNumber+1);

        await context.SaveChangesAsync(cancellationToken);
    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.NeedAnotherMeeting;

internal sealed class NeedAnotherMeetingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<NeedAnotherMeetingCommand>
{
    public async Task Handle(NeedAnotherMeetingCommand request, CancellationToken cancellationToken)
    {
        var meeting = await context.Meeting
            .FirstOrDefaultAsync(m => m.Id == request.MeetingId, cancellationToken);

        if (meeting is null)
        {
            throw new NotFoundException(nameof(Meeting), request.MeetingId.ToString());
        }

        meeting.NeededAnotherMeeting(request.MeetingId);

        await context.SaveChangesAsync(cancellationToken);
    }
}

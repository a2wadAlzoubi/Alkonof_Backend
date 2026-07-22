using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.AgreementRechedMeeting;

internal sealed class AgreementRechedMeetingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<AgreementRechedMeetingCommand>
{
    public async Task Handle(AgreementRechedMeetingCommand request, CancellationToken cancellationToken)
    {
        var meeting = await context.Meeting
            .FirstOrDefaultAsync(m => m.Id == request.MeetingId, cancellationToken);

        if (meeting is null)
        {
            throw new NotFoundException(nameof(Meeting), request.MeetingId.ToString());
        }

        meeting.AgreementRechedMeeting(request.MeetingId);

        await context.SaveChangesAsync(cancellationToken);
    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.CompleteMeeting;

internal sealed class CompleteMeetingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CompleteMeetingCommand>
{
    public async Task Handle(CompleteMeetingCommand request, CancellationToken cancellationToken)
    {
        var meeting = await context.Meeting
            .FirstOrDefaultAsync(m => m.Id == request.MeetingId, cancellationToken);

        if (meeting is null)
        {
            throw new NotFoundException(nameof(Meeting), request.MeetingId.ToString());
        }

        meeting.CompleteMeeting(request.MeetingId);

        await context.SaveChangesAsync(cancellationToken);
    }
}

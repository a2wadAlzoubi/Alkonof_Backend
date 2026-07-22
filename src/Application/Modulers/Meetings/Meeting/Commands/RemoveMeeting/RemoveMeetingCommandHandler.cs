using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.RemoveMeeting;

internal sealed class RemoveMeetingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<RemoveMeetingCommand>
{
    public async Task Handle(RemoveMeetingCommand request, CancellationToken cancellationToken)
    {
        var meeting = await context.Meeting
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (meeting is null)
        {
            throw new NotFoundException(nameof(Meeting), request.Id.ToString());
        }

        context.Meeting.Remove(meeting);
        await context.SaveChangesAsync(cancellationToken);
    }
}

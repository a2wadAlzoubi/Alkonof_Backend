using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.SetUserStatusMeeting;

internal sealed class SetUserStatusMeetingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<SetUserStatusMeetingCommand>
{
    public async Task Handle(SetUserStatusMeetingCommand request, CancellationToken cancellationToken)
    {
        var meeting = await context.Meeting
            .FirstOrDefaultAsync(m => m.Id == request.MeetingId, cancellationToken);

        if (meeting is null)
        {
            throw new NotFoundException(nameof(Meeting), request.MeetingId.ToString());
        }

        if (request.IsCustomer)
        {
            meeting.CustomerStatusMeeting(request.Status, request.MeetingId);
        }
        else
        {
            meeting.ResponsibleStatusMeeting(request.Status, request.MeetingId);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.UpdateMeeting;

internal sealed class UpdateMeetingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateMeetingCommand>
{
    public async Task Handle(UpdateMeetingCommand request, CancellationToken cancellationToken)
    {
        var meeting = await context.Meeting
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (meeting is null)
        {
            throw new NotFoundException(nameof(Meeting), request.Id.ToString());
        }

        meeting.UpdateMeeting(
            request.Id,
            request.Dto.Content,
            request.Dto.Title,
            request.Dto.OutCome,
            request.Dto.MeetingNumber,
            request.Dto.Status,
            request.Dto.ResponsibleStatus,
            request.Dto.CustomerStatus
        );

        await context.SaveChangesAsync(cancellationToken);
    }
}

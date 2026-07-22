using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Commands.UpdatePrepareMeeting;

internal sealed class UpdatePrepareMeetingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdatePrepareMeetingCommand>
{
    public async Task Handle(UpdatePrepareMeetingCommand request, CancellationToken cancellationToken)
    {
        var prepareMeeting = await context.PrepareMeeting
            .FirstOrDefaultAsync(pm => pm.Id == request.Dto.Id, cancellationToken);

        if (prepareMeeting is null)
        {
            throw new NotFoundException(nameof(PrepareMeeting), request.Dto.Id.ToString());
        }

        prepareMeeting.UpdatePrepareMeeting(
            request.Dto.Location,
            request.Dto.StartedAt,
            request.Dto.EndedAt,
            request.Dto.BookingId,
            request.Dto.MeetingId
        );

        await context.SaveChangesAsync(cancellationToken);
    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Commands.RemovePrepareMeeting;

internal sealed class RemovePrepareMeetingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<RemovePrepareMeetingCommand>
{
    public async Task Handle(RemovePrepareMeetingCommand request, CancellationToken cancellationToken)
    {
        var prepareMeeting = await context.PrepareMeeting
            .FirstOrDefaultAsync(pm => pm.Id == request.Id, cancellationToken);

        if (prepareMeeting is null)
        {
            throw new NotFoundException(nameof(PrepareMeeting), request.Id.ToString());
        }

        context.PrepareMeeting.Remove(prepareMeeting);
        await context.SaveChangesAsync(cancellationToken);
    }
}

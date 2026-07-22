using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Meetings;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Commands.CreatePrepareMeeting;

internal sealed class CreatePrepareMeetingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreatePrepareMeetingCommand, Guid>
{
    public async Task<Guid> Handle(CreatePrepareMeetingCommand request, CancellationToken cancellationToken)
    {
        var prepareMeeting = Domain.Entities.Meetings.PrepareMeeting.CreatePrepareMeeting(
            request.Dto.Location,
            request.Dto.StartedAt,
            request.Dto.EndedAt,
            request.Dto.BookingId,
            request.Dto.MeetingId
        );

        await context.PrepareMeeting.AddAsync(prepareMeeting, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return prepareMeeting.Id;
    }
}

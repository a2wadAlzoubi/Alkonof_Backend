using Alkonof_Backend.Application.Common.Interfaces;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.CreateMeeting;

internal sealed class CreateMeetingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateMeetingCommand, Guid>
{
    public async Task<Guid> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
    {
        var meeting = Domain.Entities.Meetings.Meeting.CreateMeeting(
            request.Dto.Content,
            request.Dto.Title,
            request.Dto.MeetingNumber,
            request.Dto.Status,
            request.Dto.ResponsibleStatus,
            request.Dto.CustomerStatus,
            request.Dto.OutCome
        );

        await context.Meeting.AddAsync(meeting, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return meeting.Id;
    }
}

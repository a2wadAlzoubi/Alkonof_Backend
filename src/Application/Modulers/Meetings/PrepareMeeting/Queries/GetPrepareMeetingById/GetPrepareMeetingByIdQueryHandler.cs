using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Dtos;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Queries.GetPrepareMeetingById;

internal sealed class GetPrepareMeetingByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetPrepareMeetingByIdQuery, PrepareMeetingDto>
{
    public async Task<PrepareMeetingDto> Handle(GetPrepareMeetingByIdQuery request, CancellationToken cancellationToken)
    {
        var prepareMeeting = await context.PrepareMeeting
            .AsNoTracking()
            .FirstOrDefaultAsync(pm => pm.Id == request.Id, cancellationToken);

        if (prepareMeeting is null)
        {
            throw new NotFoundException(nameof(PrepareMeeting), request.Id.ToString());
        }

        return new PrepareMeetingDto
        {
            Id = prepareMeeting.Id,
            Location = prepareMeeting.Location,
            StartedAt = prepareMeeting.StartedAt,
            EndedAt = prepareMeeting.EndedAt,
            BookingId = prepareMeeting.BookingId,
            MeetingId = prepareMeeting.MeetingId
        };
    }
}

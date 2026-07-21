using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Entities.Schedualing;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Commands.UpdateTimeTable;

internal sealed class UpdateTimeTableCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateTimeTableCommand>
{
    public async Task Handle(UpdateTimeTableCommand request, CancellationToken cancellationToken)
    {
        // 1. Authorization Check
        var requester = await context.User
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == request.RequesterId, cancellationToken);

        if (requester is null || requester.Role != UserRole.Admin)
        {
            throw new UnauthorizedAccessException("Only admins can update timetables.");
        }

        // 2. Find and Update TimeTable
        var timeTable = await context.TimeTable
            .FirstOrDefaultAsync(tt => tt.Id == request.Dto.Id, cancellationToken);

        if (timeTable is null)
        {
            throw new NotFoundException(nameof(TimeTable), request.Dto.Id.ToString());
        }

        timeTable.Update(
            request.Dto.DayOfWeek,
            request.Dto.Hour,
            request.Dto.IsReserved,
            request.Dto.ResponsibleId
        );

        await context.SaveChangesAsync(cancellationToken);
    }
}

using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Entities.Schedualing;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Commands.RemoveTimeTable;

internal sealed class RemoveTimeTableCommandHandler(IApplicationDbContext context)
    : IRequestHandler<RemoveTimeTableCommand>
{
    public async Task Handle(RemoveTimeTableCommand request, CancellationToken cancellationToken)
    {
        // 1. Authorization Check
        var requester = await context.User
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == request.RequesterId, cancellationToken);

        if (requester is null || requester.Role != UserRole.Admin)
        {
            throw new UnauthorizedAccessException("Only admins can remove timetables.");
        }

        // 2. Find and Remove TimeTable
        var timeTable = await context.TimeTable
            .FirstOrDefaultAsync(tt => tt.Id == request.TimeTableId, cancellationToken);

        if (timeTable is null)
        {
            throw new NotFoundException(nameof(TimeTable), request.TimeTableId.ToString());
        }

        context.TimeTable.Remove(timeTable);
        await context.SaveChangesAsync(cancellationToken);
    }
}

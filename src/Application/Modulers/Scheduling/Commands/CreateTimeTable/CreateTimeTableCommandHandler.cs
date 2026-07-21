using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Entities.Schedualing;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Commands.CreateTimeTable;

internal sealed class CreateTimeTableCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateTimeTableCommand, List<Guid>>
{
    public async Task<List<Guid>> Handle(CreateTimeTableCommand request, CancellationToken cancellationToken)
    {
        // 1. Authorization Check
        var requester = await context.User
            .FirstOrDefaultAsync(u => u.Id == request.RequesterId, cancellationToken);

        if (requester is null || requester.Role != UserRole.Admin)
        {
            throw new UnauthorizedAccessException("Only admins can create timetables.");
        }

        // 2. Create and Add TimeTables
        var newTimeTables = new List<TimeTable>();
        foreach (var dto in request.Dtos)
        {
            var timeTable = TimeTable.CreateSchedual(
                dto.DayOfWeek,
                dto.Hour,
                dto.IsReserved,
                dto.ResponsibleId
            );
            newTimeTables.Add(timeTable);
        }

        await context.TimeTable.AddRangeAsync(newTimeTables, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newTimeTables.Select(tt => tt.Id).ToList();
    }
}

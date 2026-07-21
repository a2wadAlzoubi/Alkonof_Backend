using Alkonof_Backend.Application.Common.Interfaces;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Commands.RestartTimeTable;

internal sealed class RestartTimeTableCommandHandler(IApplicationDbContext context)
    : IRequestHandler<RestartTimeTableCommand>
{
    public async Task Handle(RestartTimeTableCommand request, CancellationToken cancellationToken)
    {
        var allTimeTables = await context.TimeTable.ToListAsync(cancellationToken);

        foreach (var timeTable in allTimeTables)
        {
            // The EnableReservation method already sets IsReserved to false.
            timeTable.EnableReservation(timeTable);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}

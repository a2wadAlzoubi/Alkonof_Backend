using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Scheduling.Dtos;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Queries.GetTimeTablesById;

internal sealed class GetTimeTablesByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetTimeTablesByIdQuery, List<TimeTableDto>>
{
    public async Task<List<TimeTableDto>> Handle(GetTimeTablesByIdQuery request, CancellationToken cancellationToken)
    {
        var timeTables = await context.TimeTable
            .AsNoTracking()
            .Where(tt => tt.Id == request.Id)
            .Select(tt => new TimeTableDto
            {
                Id = tt.Id,
                DayOfWeek = tt.DayOfWeek,
                Hour = tt.Hour,
                IsReserved = tt.IsReserved,
                ResponsibleId = tt.ResponsibleId
            })
            .ToListAsync(cancellationToken);

        return timeTables;
    }
}

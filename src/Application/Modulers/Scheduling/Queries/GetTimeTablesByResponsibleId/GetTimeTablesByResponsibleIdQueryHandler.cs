using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Scheduling.Dtos;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Queries.GetTimeTablesByResponsibleId;

internal sealed class GetTimeTablesByResponsibleIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetTimeTablesByResponsibleIdQuery, List<TimeTableDto>>
{
    public async Task<List<TimeTableDto>> Handle(GetTimeTablesByResponsibleIdQuery request, CancellationToken cancellationToken)
    {
        var timeTables = await context.TimeTable
            .AsNoTracking()
            .Where(tt => tt.ResponsibleId == request.ResponsibleId)
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

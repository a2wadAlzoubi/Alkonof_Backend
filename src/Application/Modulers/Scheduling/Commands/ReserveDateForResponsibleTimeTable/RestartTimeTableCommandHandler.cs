using Alkonof_Backend.Application.Common.Interfaces;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Commands.ReserveDateForResponsibleTimeTable;

internal sealed class ReserveDateForResponsibleTimeTableHandler(IApplicationDbContext context)
    : IRequestHandler<ReserveDateForResponsibleTimeTableCommand>
{
    public async Task Handle(ReserveDateForResponsibleTimeTableCommand request, CancellationToken cancellationToken)
    {
        var Responsible = await context.User
            .Include(u => u.TimeTables!.Where(t => t.DayOfWeek == request.day && t.Hour == request.hour))
            .FirstOrDefaultAsync(r => r.Id == request.ResponsibleId, cancellationToken);

        if (Responsible == null && Responsible!.TimeTables == null)
        {
            throw new NotFoundException(nameof(Responsible), request.ResponsibleId.ToString());
        }
        foreach (var timeTable in Responsible.TimeTables!)
        {
            timeTable.Reserve();
        }


        await context.SaveChangesAsync(cancellationToken);
    }
}

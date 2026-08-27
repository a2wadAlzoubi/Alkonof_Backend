using MediatR;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Commands.ReserveDateForResponsibleTimeTable;

public sealed record ReserveDateForResponsibleTimeTableCommand(Guid ResponsibleId ,DayOfWeek day, int hour) : IRequest;

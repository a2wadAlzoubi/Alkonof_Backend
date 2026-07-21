namespace Alkonof_Backend.Application.Modulers.Scheduling.Dtos;

public class CreateTimeTableDto
{
    public DayOfWeek DayOfWeek { get; set; }
    public int Hour { get; set; }
    public bool IsReserved { get; set; }
    public Guid ResponsibleId { get; set; }
}

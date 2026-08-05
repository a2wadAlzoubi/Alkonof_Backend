using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;
using Alkonof_Backend.Domain.Enums;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;

public class TaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PriorityLevel Priority { get; set; }
    public DateTimeOffset StartedDate { get; set; }
    public DateTimeOffset ActualEndedDate { get; set; }
    public double Progress { get; set; }
    public Guid StageId { get; set; }
}

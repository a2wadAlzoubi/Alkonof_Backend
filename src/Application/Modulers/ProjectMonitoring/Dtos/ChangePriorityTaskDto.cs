using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;
using Alkonof_Backend.Domain.Enums;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;

public class ChangePriorityTaskDto
{
    public Guid Id { get; set; }
    public PriorityLevel Priority { get; set; }
}

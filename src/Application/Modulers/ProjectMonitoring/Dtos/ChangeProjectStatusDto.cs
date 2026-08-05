using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;

public class ChangeProjectStatusDto
{
    public Guid Id { get; set; }
    public ProjectStatus NewStatus { get; set; }
}

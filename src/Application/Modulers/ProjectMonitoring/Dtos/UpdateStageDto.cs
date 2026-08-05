using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;

public class UpdateStageDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Progress { get; set; }
    public DateTimeOffset StartedDate { get; set; }
    public DateTimeOffset ActualEndedDate { get; set; }
    public Guid ProjectId { get; set; }
    public StageStatus Status { get; set; }
}

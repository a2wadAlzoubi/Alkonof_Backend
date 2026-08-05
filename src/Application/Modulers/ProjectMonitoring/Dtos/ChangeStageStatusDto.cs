using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;

public class ChangeStageStatusDto
{
    public Guid Id { get; set; }
    public StageStatus Status { get; set; }
}

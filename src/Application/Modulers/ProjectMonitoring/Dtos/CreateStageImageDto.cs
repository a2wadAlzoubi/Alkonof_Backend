namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;

public class CreateStageImageDto
{
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid StageId { get; set; }
}

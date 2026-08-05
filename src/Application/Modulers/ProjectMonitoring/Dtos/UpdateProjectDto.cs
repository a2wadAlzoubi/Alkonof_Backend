namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;

public class UpdateProjectDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTimeOffset? EndDate { get; set; }
}

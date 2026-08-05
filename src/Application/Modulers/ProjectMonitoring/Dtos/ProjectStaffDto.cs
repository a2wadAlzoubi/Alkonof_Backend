namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;

public class ProjectStaffDto
{
    public Guid Id { get; set; }
    public Guid ResponsibalId { get; set; }
    public string Role { get; set; } = string.Empty;
    public Guid ProjectId { get; set; }
}

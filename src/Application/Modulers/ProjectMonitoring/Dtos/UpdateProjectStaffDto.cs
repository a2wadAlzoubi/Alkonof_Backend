namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;

public class UpdateProjectStaffDto
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid ResponsibalId { get; set; }
}

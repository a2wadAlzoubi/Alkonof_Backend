namespace Alkonof_Backend.Application.Modulers.Complaints.Dtos;

public class UpdateResolutionDto
{
    public Guid Id { get; set; }
    public Guid ComplintId { get; set; }
    public string ResolutionText { get; set; } = string.Empty;
}

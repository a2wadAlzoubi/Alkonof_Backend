namespace Alkonof_Backend.Application.Modulers.Complaints.Dtos;

public class CreateResolutionDto
{
    public Guid ComplintId { get; set; }
    public string ResolutionText { get; set; } = string.Empty;
}

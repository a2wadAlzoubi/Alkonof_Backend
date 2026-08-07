namespace Alkonof_Backend.Application.Modulers.Complaints.Dtos;

public class ResolutionDto
{
    public Guid Id { get; set; }
    public Guid ComplintId { get; set; }
    public string ResolutionText { get; set; } = string.Empty;
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset? LastModified { get; set; }
}

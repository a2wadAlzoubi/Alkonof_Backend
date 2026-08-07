using Alkonof_Backend.Domain.Entities.Complains.Enum;
using Alkonof_Backend.Domain.Enums;

namespace Alkonof_Backend.Application.Modulers.Complaints.Dtos;

public class UpdateComplainDto
{
    public Guid Id { get; set; }
    public ComplainStatus Status { get; set; }
    public string Subject { get; set; } = string.Empty;
    public ReferenceType ReferenceType { get; set; }
    public string Content { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
}

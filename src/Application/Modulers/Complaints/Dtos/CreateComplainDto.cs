using Alkonof_Backend.Domain.Entities.Complains.Enum;
using Alkonof_Backend.Domain.Enums;

namespace Alkonof_Backend.Application.Modulers.Complaints.Dtos;

public class CreateComplainDto
{
    public ComplainStatus Status { get; set; } = ComplainStatus.UnReaded;
    public string Subject { get; set; } = string.Empty;
    public ReferenceType ReferenceType { get; set; } = ReferenceType.Non;
    public string Content { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
}

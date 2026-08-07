using Alkonof_Backend.Domain.Entities.Complains.Enum;

namespace Alkonof_Backend.Application.Modulers.Complaints.Dtos;

public class ChangeComplainStatusDto
{
    public Guid Id { get; set; }
    public ComplainStatus Status { get; set; }
}

using Alkonof_Backend.Domain.Entities.Contracts.Enum;

namespace Alkonof_Backend.Application.Modulers.Contracts.Dtos;

public class CreateContractDto
{
    public DateTimeOffset StartedDate { get; set; }
    public DateTimeOffset? EndedDate { get; set; }
    public string PathImage { get; set; } = string.Empty;
    public ProjectType ProjectType { get; set; }
    public ContractStatus Status { get; set; }
    public Guid ProjectId { get; set; }
    public Guid CustomerId { get; set; } // Assuming CustomerId is needed for creation
}

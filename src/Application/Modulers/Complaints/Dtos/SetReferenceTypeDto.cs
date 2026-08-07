using Alkonof_Backend.Domain.Enums;

namespace Alkonof_Backend.Application.Modulers.Complaints.Dtos;

public class SetReferenceTypeDto
{
    public Guid Id { get; set; }
    public ReferenceType ReferenceType { get; set; }
}

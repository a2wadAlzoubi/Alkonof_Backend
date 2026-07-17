using Alkonof_Backend.Domain.Entities.Complains.Enum;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Domain.Entities.Complains;

public class Complain : BaseAuditableEntity
{

    private Complain(
        Guid id ,
        string type,
        ComplainStatus status,
        string subject,
        string description,
        ReferenceType referenceType,
        string content,
        Guid customerId ,
        Guid resolutionId
        )
    {
        Id = id;
        Type = type;
        Status = status;
        Subject = subject;
        Description = description;
        ReferenceType = referenceType;
        Content = content;
        CustomerId = customerId;
        ResolutionId = resolutionId;
    }

    private Complain()
    {
        
    }


    public string Type { get; private set; } = string.Empty;
    public ComplainStatus Status { get; private set; } = ComplainStatus.unReaded;
    public string Subject { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public ReferenceType ReferenceType { get; private set; } = ReferenceType.Non;
    public string Content { get; private set; } = string.Empty;

    // Relations
    public User? Customer { get; private set; }
    public Guid CustomerId { get; private set; }
    public Resolution? Resolution { get; private set; }
    public Guid? ResolutionId { get; private set; }
}

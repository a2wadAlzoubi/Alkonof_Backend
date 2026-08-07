using Alkonof_Backend.Domain.Entities.Complains.Enum;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Domain.Entities.Complains;

public class Complain : BaseAuditableEntity
{

    private Complain(
        Guid id ,
        ComplainStatus status,
        string subject,
        ReferenceType referenceType,
        string content,
        Guid customerId
        )
    {
        Id = id;
        Status = status;
        Subject = subject;
        ReferenceType = referenceType;
        Content = content;
        CustomerId = customerId;
    }

    private Complain()
    {
        
    }
    public ComplainStatus Status { get; private set; } = ComplainStatus.UnReaded;
    public string Subject { get; private set; } = string.Empty;

    public ReferenceType ReferenceType { get; private set; } = ReferenceType.Non;
    public string Content { get; private set; } = string.Empty;

    // Relations
    public User? Customer { get; private set; }
    public Guid CustomerId { get; private set; }
    public static Complain Create(
        ComplainStatus status,
        string subject,
        ReferenceType referenceType,
        string content,
        Guid customerId
        )
    {
        return new Complain(Guid.NewGuid(), status, subject, referenceType, content, customerId);
    }
    public void Update(
        ComplainStatus status,
        string subject,
        ReferenceType referenceType,
        string content,
        Guid customerId
        )
    {
        Status = status;
        Subject = subject;
        ReferenceType = referenceType;
        Content = content;
        CustomerId = customerId;
    }
    public void ChangeComplainStatus(ComplainStatus status)
    {
        Status = status;
    }
    public void SetReferenceType(ReferenceType referenceType)
    {
        ReferenceType = referenceType;
    }

}

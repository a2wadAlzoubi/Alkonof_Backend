using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Notifications.Enum;

namespace Alkonof_Backend.Domain.Entities.Notifications;

public class Notification : BaseAuditableEntity
{
    private Notification()
    {
        
    }
    private Notification(Guid id, Guid userId, Guid templateId, NotificationStatus status, ReferenceType referenceType, Guid referenceId, bool isRead, DateTime createdAt, User user, NotificationTemplet templet)
    {
        Id = id;
        UserId = userId;
        TemplateId = templateId;
        Status = status;
        ReferenceType = referenceType;
        ReferenceId = referenceId;
        IsRead = isRead;
        CreatedAt = createdAt;
    }

    public NotificationStatus Status { get; private set; } = NotificationStatus.unRead;
    public ReferenceType ReferenceType { get; private set; } = ReferenceType.Non;
    public Guid ReferenceId { get; private set; }
    public bool IsRead { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;

    // Relations :
    public User? User { get; private set; }
    public Guid UserId { get; private set; }
    public NotificationTemplet? Templet { get; private set; }
    public Guid TemplateId { get; private set; }
}

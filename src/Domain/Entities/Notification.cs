using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

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
        User = user;
        Templet = templet;
    }

    public NotificationStatus Status { get; set; } = NotificationStatus.unRead;
    public ReferenceType ReferenceType { get; set; } = ReferenceType.non;
    public Guid ReferenceId { get; set; }
    public bool IsRead { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    // Relations :
    public User? User { get; set; }
    public Guid UserId { get; set; }
    public NotificationTemplet? Templet { get; set; }
    public Guid TemplateId { get; set; }
}

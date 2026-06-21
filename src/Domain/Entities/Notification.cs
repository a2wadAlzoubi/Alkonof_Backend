using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class Notification : BaseAuditableEntity
{
    private Notification()
    {
        
    }
    private Notification(int id, Guid userId, Guid templateId, string status, string referenceType, int referenceId, bool isRead, DateTime createdAt, User user, NotificationTemplet templet)
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

    public string Status { get; set; } = string.Empty;
    public string ReferenceType { get; set; } = string.Empty;
    public int ReferenceId { get; set; }
    public bool IsRead { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    // Relations :
    public User? User { get; set; }
    public Guid UserId { get; set; }
    public NotificationTemplet? Templet { get; set; }
    public Guid TemplateId { get; set; }
}

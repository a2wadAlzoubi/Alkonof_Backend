using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class AuditEntity : BaseAuditableEntity
{
    private AuditEntity()
    {
        
    }
    private AuditEntity(Guid id, string userName, Guid userId, AuditAction action, ReferenceType referenceEntityType, Guid referenceID, DateTime timestamp, AuditCategory category, string fileName ,Guid auditChangeId)
    {
        Id = id;
        UserName = userName;
        UserId = userId;
        Action = action;
        ReferenceType = referenceEntityType;
        ReferenceId = referenceID;
        Timestamp = timestamp;
        Category = category;
        FileName = fileName;
        AuditChangeId = auditChangeId;
    }

    public string UserName { get; private set; } = string.Empty;
    public AuditAction Action { get; private set; } = AuditAction.unknown;
    public ReferenceType ReferenceType { get; private set; } = ReferenceType.non;
    public Guid ReferenceId { get; private set; }
    public DateTimeOffset Timestamp { get; private set; } 
    public AuditCategory Category { get; private set; } = AuditCategory.unknown;
    public string FileName { get; private set; } = string.Empty;

    //Relations
    public User? User { get; private set; }
    public Guid UserId { get; private set; }

    public AuditChange? AuditChange { get; private set;}
    public Guid AuditChangeId { get; private set;}
}

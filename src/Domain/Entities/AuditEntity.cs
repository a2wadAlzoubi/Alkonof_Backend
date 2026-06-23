using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class AuditEntity : BaseAuditableEntity
{
    private AuditEntity()
    {
        
    }
    private AuditEntity(Guid id, string userName, Guid userId, AuditAction action, ReferenceType referenceEntityType, Guid referenceID, DateTime timestamp, AuditCategory category, string fileName)
    {
        Id = id;
        UserName = userName;
        UserId = userId;
        Action = action;
        ReferenceType = referenceEntityType;
        ReferenceID = referenceID;
        Timestamp = timestamp;
        Category = category;
        FileName = fileName;
        AuditChanges = new List<AuditChange>();
    }

    public string UserName { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public AuditAction Action { get; set; } = AuditAction.unknown;
    public ReferenceType ReferenceType { get; set; } = ReferenceType.non;
    public Guid ReferenceID { get; set; }
    public DateTimeOffset Timestamp { get; set; } 
    public AuditCategory Category { get; set; } = AuditCategory.unknown;
    public string FileName { get; set; } = string.Empty;

    public ICollection<AuditChange>? AuditChanges
    {
        get;
    } 
}

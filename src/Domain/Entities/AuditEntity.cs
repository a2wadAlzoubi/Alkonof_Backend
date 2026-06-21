using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class AuditEntity : BaseAuditableEntity
{
    private AuditEntity()
    {
        
    }
    private AuditEntity(int  id, string userName, int userId, int action, string referenceEntityType, int referenceID, DateTime timestamp, string category, string fileName)
    {
        Id = id;
        UserName = userName;
        UserId = userId;
        Action = action;
        ReferenceEntityType = referenceEntityType;
        ReferenceID = referenceID;
        Timestamp = timestamp;
        Category = category;
        FileName = fileName;
    }

    public string UserName { get; set; } = string.Empty;
    public int UserId { get; set; }
    public int Action {  get; set; }
    public string ReferenceEntityType { get; set; } = string.Empty;
    public int ReferenceID { get; set; }
    public DateTimeOffset Timestamp { get; set; } 
    public string Category { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;

    public ICollection<AuditEntity> AuditEntities
    {
        get;
    } = new List<AuditEntity>();
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class Complain : BaseAuditableEntity
{
    private Complain()
    {
        
    }
    private Complain(int  id, int customerId, string type, string status, string subject, string description, string referenceType, int referenceId, string content)
    {
        Id = id;
        CustomerId = customerId;
        Type = type;
        Status = status;
        Subject = subject;
        Description = description;
        ReferenceType = referenceType;
        ReferenceId = referenceId;
        Content = content;
    }

    public int CustomerId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string ReferenceType { get; set; } = string.Empty;
    public int ReferenceId { get; set; }
    public string Content { get; set; } = string.Empty;

    public ICollection<Resolution> Resolutions { get; set; } = new List<Resolution>();
}

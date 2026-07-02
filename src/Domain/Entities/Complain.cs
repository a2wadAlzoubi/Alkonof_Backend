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
    private Complain(Guid id, Guid customerId, string type, string status, string subject, string description, ReferenceType referenceType, Guid referenceId, string content)
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

    public Guid CustomerId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ReferenceType ReferenceType { get; set; } = ReferenceType.non;
    public Guid ReferenceId { get; set; }
    public string Content { get; set; } = string.Empty;

    public ICollection<Resolution> Resolutions { get; set; } = new List<Resolution>();
}

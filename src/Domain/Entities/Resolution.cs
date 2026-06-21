using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class Resolution : BaseAuditableEntity
{
    private Resolution()
    {
        
    }
    private Resolution(int id, Guid complintId, string resolutionText)
    {
        Id = id;
        ComplainId = complintId;
        ResolutionText = resolutionText;
    }

    public string ResolutionText { get; set; } = string.Empty;

    // Relations
    public Complain? Complain { get; set; } = null!;
    public Guid ComplainId { get; set; }
}

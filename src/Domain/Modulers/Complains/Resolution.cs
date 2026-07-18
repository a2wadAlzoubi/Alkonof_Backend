using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Complains;

public class Resolution : BaseAuditableEntity
{
    private Resolution()
    {
        
    }
    private Resolution(Guid id, Guid complintId, string resolutionText)
    {
        Id = id;
        ResolutionText = resolutionText;
    }

    public string ResolutionText { get; private set; } = string.Empty;

    // Relations
    public ICollection<Complain>? Complains { get; private set; } = new List<Complain>();
}

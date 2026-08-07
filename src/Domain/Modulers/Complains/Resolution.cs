

namespace Alkonof_Backend.Domain.Entities.Complains;

public class Resolution : BaseAuditableEntity
{
    private Resolution()
    {
        
    }
    private Resolution(Guid id, Guid complintId, string resolutionText)
    {
        Id = id;
        ComplintId = complintId;
        ResolutionText = resolutionText;
    }

    public Guid ComplintId { get; private set; }
    public string ResolutionText { get; private set; } = string.Empty;

    // Relations
    public ICollection<Complain>? Complains { get; private set; } = new List<Complain>();

    public static Resolution Create(Guid complintId, string resolutionText)
    {
        return new Resolution(Guid.NewGuid() ,  complintId, resolutionText);
    }
    public void Update(Guid complintId, string resolutionText)
    {
        ComplintId = complintId;
        ResolutionText = resolutionText;
    }
}

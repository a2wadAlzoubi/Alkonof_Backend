using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.GeneralEnum;

namespace Alkonof_Backend.Domain.Entities.Notifications;

public class NotificationTemplet : BaseAuditableEntity
{
    public NotificationTemplet(
        Guid id ,
        string titleTemplate,
        string bodyTemplate,
        bool isActive,
        ReferenceType reference,
        Guid referenceId)
    {
        Id = id; 
        TitleTemplate = titleTemplate;
        BodyTemplate = bodyTemplate;
        IsActive = isActive;
        Reference = reference;
        ReferenceId = referenceId;
    }

    private NotificationTemplet()
    {
        
    }


    public string TitleTemplate { get; private set; } = string.Empty;
    public string BodyTemplate { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = false;
    public ReferenceType Reference { get; private set; } = ReferenceType.Non;
    public Guid ReferenceId { get; private set; }

    // Relations
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}

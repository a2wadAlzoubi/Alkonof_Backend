using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class NotificationTemplet : BaseAuditableEntity
{
    private NotificationTemplet()
    {
        
    }
    private NotificationTemplet(int id, string code, string titleTemplate, string bodyTemplate, bool isActive, string reference)
    {
        Id = id;
        Code = code;
        TitleTemplate = titleTemplate;
        BodyTemplate = bodyTemplate;
        IsActive = isActive;
        Reference = reference;
    }

    public string Code { get; set; } = string.Empty;
    public string TitleTemplate { get; set; } = string.Empty;
    public string BodyTemplate { get; set; } = string.Empty;
    public bool IsActive { get; set; } = false;
    public string Reference { get; set; } = string.Empty;

}

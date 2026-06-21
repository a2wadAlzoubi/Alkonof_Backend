using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class AuditChange : BaseAuditableEntity
{
    private AuditChange()
    {
        
    }
    private AuditChange(int id, Guid auditEntryId, string oldValue, string newValue, string content)
    {
        Id = id;
        AuditEntryId = auditEntryId;
        OldValue = oldValue;
        NewValue = newValue;
        Content = content;
    }

    public string OldValue { get; set; } = string.Empty;
    public string NewValue { get; set; } = string.Empty!;
    public string Content { get; set; } = string.Empty;

    // Relations :
    public AuditEntity? AuditEntity { get; set; }
    public Guid AuditEntryId { get; set; }

    // وراثه من BaseAuditableEntity
    // حدف Id
    // كاشي فيه Id => Guid
    // تجهيز private empty constractor , privare constractor(...)
    // تجهيز Resolutions = new List<Resolution>(); ضمن constractor (...) ... من ناحية many

    // حدف العلاقه الباراميتر من الباني ضمن constractor (...) ... من ناحية one     و اضافة اشارة استفهام
    // اضافة enum الى انواع البيانات
    // اضافة DateTimeOffset
}

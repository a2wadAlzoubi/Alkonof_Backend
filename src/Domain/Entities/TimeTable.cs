using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class TimeTable : BaseAuditableEntity
{
    public TimeTable(DayOfWeek dayOfWeek, int hour, bool isFalse, User responsibal, Guid responsibalId)
    {
        DayOfWeek = dayOfWeek;
        Hour = hour;
        IsFalse = isFalse;
        Responsibal = responsibal;
        ResponsibalId = responsibalId;
    }

    DayOfWeek DayOfWeek { get; set; }
    public int Hour{ get; set; }
    public bool IsFalse { get; set; }
    
    //Relations :
    public User Responsibal { get; set; }
    public Guid ResponsibalId { get; set; } 
}

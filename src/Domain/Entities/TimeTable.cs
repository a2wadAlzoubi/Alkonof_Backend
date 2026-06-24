using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class TimeTable : BaseAuditableEntity
{
    private TimeTable()
    {
        
    }
    private TimeTable(DayOfWeek dayOfWeek, int hour, bool isFalse, User responsibal, Guid responsibalId)
    {
        DayOfWeek = dayOfWeek;
        Hour = hour;
        IsFalse = isFalse;
        Responsibal = responsibal;
        ResponsibalId = responsibalId;
    }

    DayOfWeek DayOfWeek { get; set; } = DayOfWeek.Sunday;
    public int Hour { get; set; } = 0;
    public bool IsFalse { get; set; } = false;
    
    //Relations :
    public User? Responsibal { get; set; }
    public Guid ResponsibalId { get; set; } 
}

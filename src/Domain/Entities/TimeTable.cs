using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class TimeTable : BaseAuditableEntity
{
    private TimeTable()
    {
        
    }
    private TimeTable(Guid id ,DayOfWeek dayOfWeek, int hour, bool isFalse, Guid responsibalId)
    {
        Id = id;
        DayOfWeek = dayOfWeek;
        Hour = hour;
        IsFalse = isFalse;
        ResponsibalId = responsibalId;
    }

    public DayOfWeek DayOfWeek { get; set; } = DayOfWeek.Sunday;
    public int Hour { get; private set; } = 0;
    public bool IsFalse { get; private set; } = false;
    
    //Relations :
    public User? Responsibal { get; private set; }
    public Guid ResponsibalId { get; private set; } 
}

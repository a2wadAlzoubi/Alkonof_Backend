using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Domain.Entities.Schedualing;

public class TimeTable : BaseAuditableEntity
{
    private TimeTable()
    {
        
    }
    private TimeTable(Guid id ,DayOfWeek dayOfWeek, int hour, bool isReserved, Guid responsibalId)
    {
        Id = id;
        DayOfWeek = dayOfWeek;
        Hour = hour;
        IsReserved = isReserved;
        ResponsibalId = responsibalId;
    }

    [Required]
    public DayOfWeek DayOfWeek { get; set; } = DayOfWeek.Sunday;
    [Required]
    public int Hour { get; private set; } = 0;
    public bool IsReserved { get; private set; } = false;
    
    //Relations :
    public User? Responsibal { get; private set; }
    public Guid ResponsibalId { get; private set; } 

    public static TimeTable CreateSchedual(DayOfWeek day , int hour , bool isReserved , Guid responsibalId)
    {
        return new TimeTable(Guid.NewGuid() , day, hour , isReserved , responsibalId);
    }

    public void EnableReservation()
    {
        IsReserved = false;
    }
    public void BanReservation()
    {
        IsReserved = true;
    }
}

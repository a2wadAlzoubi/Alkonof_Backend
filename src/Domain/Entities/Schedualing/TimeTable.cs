using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Timers;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Schedualing.Event;

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
    [Required]
    public Guid ResponsibalId { get; private set; } 

    public static TimeTable CreateSchedual(DayOfWeek day , int hour , bool isReserved , Guid responsibalId)
    {
        return new TimeTable(Guid.NewGuid() , day, hour , isReserved , responsibalId);
    }

    public void EnableReservation(TimeTable time)
    {
        IsReserved = false;
        AddDomainEvent(new EnableReservationEvent(time));
    }
    public void BanReservation(TimeTable time)
    {
        IsReserved = true;

        AddDomainEvent(new BanReservationEvent(time));
    }
}

using System.ComponentModel.DataAnnotations;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Schedualing.Event;

namespace Alkonof_Backend.Domain.Entities.Schedualing;

public class TimeTable : BaseAuditableEntity
{
    private TimeTable()
    {
        
    }
    private TimeTable(Guid id ,DayOfWeek dayOfWeek, int hour, bool isReserved, Guid responsibleId)
    {
        Id = id;
        DayOfWeek = dayOfWeek;
        Hour = hour;
        IsReserved = isReserved;
        ResponsibleId = responsibleId;
    }

    [Required]
    public DayOfWeek DayOfWeek { get; set; } = DayOfWeek.Sunday;
    [Required]
    public int Hour { get; private set; } = 0;
    public bool IsReserved { get; private set; } = false;
    
    //Relations :
    public User? Responsible { get; private set; }
    [Required]
    public Guid ResponsibleId { get; private set; } 

    public static TimeTable CreateSchedual(DayOfWeek day , int hour , bool isReserved , Guid responsibleId)
    {
        return new TimeTable(Guid.NewGuid() , day, hour , isReserved , responsibleId);
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

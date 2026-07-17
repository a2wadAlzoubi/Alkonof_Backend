namespace Alkonof_Backend.Domain.Entities.Schedualing.Event;

public class EnableReservationEvent : BaseEvent 
{
    public EnableReservationEvent(TimeTable time)
    {
        this.SchedualingTime = time;
    }
    public TimeTable SchedualingTime { get; set; }
}

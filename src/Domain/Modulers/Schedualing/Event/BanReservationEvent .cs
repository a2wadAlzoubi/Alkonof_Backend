namespace Alkonof_Backend.Domain.Entities.Schedualing.Event;

public class BanReservationEvent : BaseEvent
{
    public BanReservationEvent(TimeTable time)
    {
        this.SchedualingTime = time;
    }
    public TimeTable SchedualingTime { get; set; }
}

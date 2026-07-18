using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.Meetings.Events.MeetingStatus;

public class MeetingCreatedEvent : BaseEvent
{
    public MeetingCreatedEvent(Guid meetingId, int meetingNumber)
    {
        MeetingId = meetingId;
        MeetingNumber = meetingNumber;
    }

    public Guid MeetingId { get; set; }
    public int MeetingNumber { get; set; }
}

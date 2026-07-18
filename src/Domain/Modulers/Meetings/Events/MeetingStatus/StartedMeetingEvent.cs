using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.Meetings.Events.MeetingStatus;

public class StartedMeetingEvent : BaseEvent
{
    public StartedMeetingEvent(Guid meetingId)
    {
        MeetingId = meetingId;
    }

    public Guid MeetingId { get; set; }
}

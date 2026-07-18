using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.Meetings.Events.OutcomeMeeting;

public class NeededAnotherMeetingEvent : BaseEvent
{
    public NeededAnotherMeetingEvent(Guid meetingId)
    {
        MeetingId = meetingId;
    }

    public Guid MeetingId { get; set; }
}

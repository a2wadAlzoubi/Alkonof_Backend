using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.Meetings.Events.OutcomeMeeting;

public class RejectedMeetingEvent : BaseEvent
{
    public RejectedMeetingEvent(Guid meetingId, int nextMeetingNumber)
    {
        MeetingId = meetingId;
        NextMeetingNumber = nextMeetingNumber;
    }

    public Guid MeetingId { get; set; }
    public int NextMeetingNumber{ get; set; }
}

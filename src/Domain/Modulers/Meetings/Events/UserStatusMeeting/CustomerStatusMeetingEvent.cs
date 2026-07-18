using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.Meetings.Enum;

namespace Alkonof_Backend.Domain.Modulers.Meetings.Events.UserStatusMeeting;

public class CustomerStatusMeetingEvent : BaseEvent
{
    public CustomerStatusMeetingEvent(Guid meetingId, MeetingUserStatus status)
    {
        MeetingId = meetingId;
        Status = status;
    }

    public Guid MeetingId { get; set; }
    public MeetingUserStatus Status { get; set; }
}

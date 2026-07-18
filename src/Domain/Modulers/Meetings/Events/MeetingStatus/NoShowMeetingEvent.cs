using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.Meetings.Enum;

namespace Alkonof_Backend.Domain.Modulers.Meetings.Events.MeetingStatus;

public class NoShowMeetingEvent : BaseEvent
{
    public NoShowMeetingEvent(Guid meetingId, MeetingUserStatus customerAnswer, MeetingUserStatus responsibleAnswer)
    {
        MeetingId = meetingId;
        CustomerAnswer = customerAnswer;
        ResponsibleAnswer = responsibleAnswer;
    }

    public Guid MeetingId { get; set; }
    public MeetingUserStatus CustomerAnswer{ get; set; }
    public MeetingUserStatus ResponsibleAnswer{ get; set; }
}

using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.Meetings.Enum;

namespace Alkonof_Backend.Domain.Entities.Meetings;

public class Meeting : BaseAuditableEntity
{
    private Meeting()
    {
        
    }
    private Meeting(
        Guid id,
        string content,
        MeetingOutCome outCome,
        int meetingNumber,
        MeetingStatus status,
        MeetingUserStatus responsibalStatus,
        MeetingUserStatus customerStatus)
    {
        this.Id = id;
        this.Content = content;
        this.OutCome = outCome;
        this.MeetingNumber = meetingNumber;
        this.Status = status;
        this.ResponsibalStatus = responsibalStatus;
        this.CustomerStatus = customerStatus;
    }

    public string Content { get; private set; } = string.Empty;
    public MeetingOutCome OutCome { get; private set; } = MeetingOutCome.NotStarted;
    public int MeetingNumber { get; private set; } = 0;
    public MeetingStatus Status { get; private set; } = MeetingStatus.NotStarted;
    public MeetingUserStatus ResponsibalStatus { get; private set; } = MeetingUserStatus.Adsent;
    public MeetingUserStatus CustomerStatus { get; private set; }

    // Relations
    public PrepareMeeting? PrepareMeeting { get; private set; }


}

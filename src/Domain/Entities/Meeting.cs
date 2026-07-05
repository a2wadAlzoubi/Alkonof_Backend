using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

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

    public enum MeetingStatus
    {
        Scheduled=0,
        Completed=1,
        Cancelled=3,
        NoShow=4,
        NotStarted = 3
    }
    public enum MeetingOutCome
    {

        AgreementReched=0,
        NeededAnotherMeeting=1,
        Rejected=2,
        NotStarted=3
    }
    public enum MeetingUserStatus
    {
        Attended=0,
        Adsent=1
    }
}

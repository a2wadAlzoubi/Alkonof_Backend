using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class Meeting
{
   public enum enMeetingStatus
    {
        Scheduled=0,
        Completed=1,
        Cancelled=3,
        NoShow=4
    }
    public enum enMeetingOutCom
    {
        AgreementReched=0,
        NeededAnotherMeeting=1,
        Rejected=2
    }
    public enum enMeetingUserStatus
    {
        Attended=0,
        Adsent=1
    }
}

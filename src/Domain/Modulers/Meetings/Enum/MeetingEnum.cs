using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Meetings.Enum;

public enum MeetingStatus
{
    Scheduled = 0,
    Completed = 1,
    Cancelled = 3,
    NoShow = 4,
    NotStarted = 3
}
public enum MeetingOutCome
{

    AgreementReched = 0,
    NeededAnotherMeeting = 1,
    Rejected = 2,
    NotStarted = 3
}
public enum MeetingUserStatus
{
    Attended = 0,
    Adsent = 1
}

using System.ComponentModel.DataAnnotations;
using Alkonof_Backend.Domain.Entities.Meetings.Enum;
using Alkonof_Backend.Domain.Modulers.Meetings.Events.MeetingStatus;
using Alkonof_Backend.Domain.Modulers.Meetings.Events.OutcomeMeeting;
using Alkonof_Backend.Domain.Modulers.Meetings.Events.UserStatusMeeting;

namespace Alkonof_Backend.Domain.Entities.Meetings;

public class Meeting : BaseAuditableEntity
{
    private Meeting()
    {
        
    }
    private Meeting(
        Guid id,
        string content,
        string title,
        int meetingNumber,
        MeetingOutCome outCome = MeetingOutCome.NotStarted,
        MeetingStatus status = MeetingStatus.NotStarted,
        MeetingUserStatus responsibleStatus = MeetingUserStatus.Non,
        MeetingUserStatus customerStatus = MeetingUserStatus.Non
        )
    {
        this.Id = id;
        this.Content = content;
        this.Title = title;
        this.OutCome = outCome;
        this.MeetingNumber = meetingNumber;
        this.Status = status;
        this.ResponsibleStatus = responsibleStatus;
        this.CustomerStatus = customerStatus;
    }
    [Required]
    [StringLength(200)]
    public string Title { get; private set; } = string.Empty;
    public string Content { get; private set; } = string.Empty;
    [Required]
    public MeetingOutCome OutCome { get; private set; } = MeetingOutCome.NotStarted;
    [Required]
    public int MeetingNumber { get; private set; } = 0;
    [Required]
    public MeetingStatus Status { get; private set; } = MeetingStatus.NotStarted;
    [Required]
    public MeetingUserStatus ResponsibleStatus { get; private set; } = MeetingUserStatus.Non;
    [Required]
    public MeetingUserStatus CustomerStatus { get; private set; } = MeetingUserStatus.Non;

    // Relations
    public PrepareMeeting? PrepareMeeting { get; private set; }

    public static Meeting CreateMeeting(
        string content,
        string title,
        int meetingNumber,
        MeetingStatus status,
        MeetingUserStatus responsibalStatus,
        MeetingUserStatus customerStatus,
        MeetingOutCome outCome = MeetingOutCome.NotStarted
        )
    {
        var meeting = new Meeting(Guid.NewGuid() , content , title  , meetingNumber , outCome , status , responsibalStatus , customerStatus);
        meeting.AddDomainEvent(new MeetingCreatedEvent(meeting.Id, meetingNumber));
        return meeting;
    }
    public void UpdateMeeting(
        Guid id ,
        string content,
        string title,
        MeetingOutCome outCome,
        int meetingNumber,
        MeetingStatus status,
        MeetingUserStatus responsibalStatus,
        MeetingUserStatus customerStatus)
    {
        Content = content;
        Title = title;
        OutCome = outCome;
        MeetingNumber = meetingNumber;
        Status = status;
        ResponsibleStatus = responsibalStatus;
        CustomerStatus = customerStatus;
        AddDomainEvent(new MeetingUpdatedEvent(id));
    }

    // Meeting Status
    public void StartMeeting(Guid meetingId)
    {
        Status = MeetingStatus.Started;
        AddDomainEvent(new StartedMeetingEvent(meetingId));
    }
    public void CancellMeeting(Guid meetingId)
    {
        Status = MeetingStatus.Cancelled;
        AddDomainEvent(new CancelledMeetingEvent(meetingId));
    }
    public void NoShowMeeting(Guid meetingId , MeetingUserStatus responsibleAnswer , MeetingUserStatus customerAnswer)
    {
        Status = MeetingStatus.NoShow;
        AddDomainEvent(new NoShowMeetingEvent(meetingId , customerAnswer , responsibleAnswer));
    }
    public void CompleteMeeting(Guid meetingId)
    {
        Status = MeetingStatus.Completed;
        AddDomainEvent(new CompletedMeetingEvent(meetingId));
    }

    // User Status Meeting
    public void CustomerStatusMeeting(MeetingUserStatus status , Guid meetingId)
    {
        CustomerStatus = status;
        AddDomainEvent(new CustomerStatusMeetingEvent(meetingId , status));
    }
    public void ResponsibleStatusMeeting(MeetingUserStatus status , Guid meetingId)
    {
        ResponsibleStatus = status ;
        AddDomainEvent(new ResponsibleStatusMeetingEvent(meetingId , status));
    }

    // Outcome Meeting
    public void AgreementRechedMeeting(Guid meetingId)
    {
        OutCome = MeetingOutCome.AgreementReched;
        AddDomainEvent(new AgrementRechedMeetingEvent(meetingId));
    }
    public void RejectedMeeting(Guid meetingId , int nextMeetingNumber)
    {
        OutCome = MeetingOutCome.Rejected;
        AddDomainEvent(new RejectedMeetingEvent(meetingId , nextMeetingNumber));
    }
    public void NeededAnotherMeeting(Guid meetingId)
    {
        OutCome = MeetingOutCome.NeededAnotherMeeting;
        AddDomainEvent(new NeededAnotherMeetingEvent(meetingId));
    }

}

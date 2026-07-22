using Alkonof_Backend.Domain.Entities.Meetings.Enum;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Dtos;

public class CreateMeetingDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public MeetingOutCome OutCome { get; set; }
    public int MeetingNumber { get; set; }
    public MeetingStatus Status { get; set; }
    public MeetingUserStatus ResponsibleStatus { get; set; }
    public MeetingUserStatus CustomerStatus { get; set; }
}

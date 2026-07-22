namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Dtos;

public class PrepareMeetingDto
{
    public Guid Id { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset EndedAt { get; set; }
    public Guid BookingId { get; set; }
    public Guid MeetingId { get; set; }
}

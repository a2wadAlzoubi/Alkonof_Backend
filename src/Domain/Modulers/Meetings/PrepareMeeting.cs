using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Alkonof_Backend.Domain.Entities.Bookings;

namespace Alkonof_Backend.Domain.Entities.Meetings;

public class PrepareMeeting : BaseAuditableEntity
{
    private PrepareMeeting(Guid id, string location, DateTimeOffset startedAt, DateTimeOffset endedAt, Guid bookingId, Guid meetingId)
    {
        Id = id;
        Location = location;
        StartedAt = startedAt;
        EndedAt = endedAt;
        BookingId = bookingId;
        MeetingId = meetingId;
    }

    private PrepareMeeting()
    {

    }


    [Required]
    [StringLength(250)]
    public string Location { get; private set; } = string.Empty;
    [Required]
    public DateTimeOffset StartedAt { get; private set; }
    [Required]
    public DateTimeOffset EndedAt { get; private set; }

    // Relations
    public Booking? Booking { get; private set; }
    [Required]
    public Guid BookingId { get; private set; }
    public Meeting? Meeting { get; private set; }
    public Guid MeetingId { get; private set; }

    public static PrepareMeeting CreatePrepareMeeting(string location, DateTimeOffset startedAt, DateTimeOffset endedAt, Guid bookingId, Guid meetingId)
    {
        var meeting = new PrepareMeeting(Guid.NewGuid(), location, startedAt, endedAt, bookingId, meetingId);
        return meeting;
    }
    public void UpdatePrepareMeeting(string location, DateTimeOffset startedAt, DateTimeOffset endedAt, Guid bookingId, Guid meetingId)
    {
        Location = location;
        StartedAt = startedAt;
        EndedAt = endedAt;
        BookingId = bookingId;
        MeetingId = meetingId;
    }
}

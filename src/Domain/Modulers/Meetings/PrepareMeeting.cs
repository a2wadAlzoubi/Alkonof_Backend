using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.Bookings;

namespace Alkonof_Backend.Domain.Entities.Meetings;

public class PrepareMeeting : BaseAuditableEntity
{
    private PrepareMeeting()
    {
        
    }
    private PrepareMeeting(Guid id ,Guid bookingId , Guid? meetingId)
    {
        Id = id;
        BookingId = bookingId;
        MeetingId = meetingId;
    }

    public Meeting? Meeting { get; private set; }
    public Guid? MeetingId { get; private set; }
    public Booking? Booking{ get; private set; }
    public Guid BookingId{ get; private set; }
}

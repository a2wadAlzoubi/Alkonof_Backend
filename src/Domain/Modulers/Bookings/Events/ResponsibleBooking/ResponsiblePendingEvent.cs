using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Modulers.Bookings.Events.ResponsibleBooking;

public class ResponsiblePendingEvent : BaseEvent
{
    public ResponsiblePendingEvent(Guid bookingId, Guid responsibleId)
    {
        BookingId = bookingId;
        ResponsibleId = responsibleId;
    }

    public Guid BookingId { get; set; }
    public Guid ResponsibleId { get; set; }
}

using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;

namespace Alkonof_Backend.Domain.Modulers.Bookings.Events.ResponsibleBooking;

public class AssignResponsibleAnswerEvent : BaseEvent
{
    public AssignResponsibleAnswerEvent(Guid bookingId, Guid responsibleId, Decision responsibleAnswer)
    {
        BookingId = bookingId;
        ResponsibleId = responsibleId;
        ResponsibleAnswer = responsibleAnswer;
    }

    public Guid BookingId { get; set; }
    public Guid ResponsibleId { get; set; }
    public Decision ResponsibleAnswer{ get; set; }
}

using Alkonof_Backend.Domain.Entities.Bookings.Enum;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Events;

public record ResponsibleAnswerAssignedEvent(Guid BookingId, Decision Decision );
public record UpdateBookingStatusEvent(Guid BookingId);
public record UnResevedHourEvent(Guid ResponsibleId , int UnResevedHour);
public record ResevedHourEvent(Guid ResponsibleId, int ResevedHour);


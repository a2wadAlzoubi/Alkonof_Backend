using Alkonof_Backend.Domain.Entities.Bookings.Enum;

namespace Alkonof_Backend.Application.Modulers.Bookings.Book.Events;

public record ResponsibleAnswerAssignedEvent(Guid BookingId, Decision Decision );

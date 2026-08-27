using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Entities.Schedualing;
using Alkonof_Backend.Domain.Exceptions;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Alkonof_Backend.Infrastructure.Consumers;

public class ReserveDateForResponsibleTimeTableConsumer(ILogger<ReserveDateForResponsibleTimeTableConsumer> logger, IApplicationDbContext context) : IConsumer<ResponsibleAnswerAssignedEvent>
{
    public async Task Consume(ConsumeContext<ResponsibleAnswerAssignedEvent> consumeContext)
    {
        if (consumeContext.Message.Decision != Decision.Approved)
        {
            return;
        }

        logger.LogInformation("Attempting to reserve timetable slot for booking {BookingId}", consumeContext.Message.BookingId);

        var booking = await context.Booking
            .FirstOrDefaultAsync(b => b.Id == consumeContext.Message.BookingId);

        if (booking is null)
        {
            throw new NotFoundException(nameof(Booking), consumeContext.Message.BookingId.ToString());
        }

        var timeSlot = await context.TimeTable
            .FirstOrDefaultAsync(t => 
                t.ResponsibleId == booking.ResponsibleId &&
                t.DayOfWeek == booking.ConfirmedAt.DayOfWeek &&
                t.Hour == booking.ConfirmedAt.Hour);

        if (timeSlot is null)
        {
            logger.LogWarning("No available timetable slot found for Responsible {ResponsibleId} at {DayOfWeek} {Hour}h for booking {BookingId}",
                booking.ResponsibleId, booking.ConfirmedAt.DayOfWeek, booking.ConfirmedAt.Hour, booking.Id);
            // Optionally, you could throw an exception or publish a "ReservationFailed" event here.
            return;
        }

        if (timeSlot.IsReserved)
        {
            logger.LogWarning("Timetable slot {TimeSlotId} is already reserved for Responsible {ResponsibleId} at {DayOfWeek} {Hour}h. Booking {BookingId} cannot be reserved.",
                timeSlot.Id, booking.ResponsibleId, booking.ConfirmedAt.DayOfWeek, booking.ConfirmedAt.Hour, booking.Id);
            // This indicates a potential double-booking scenario.
            // You might want to publish an event to notify an admin.
            return;
        }

        timeSlot.Reserve();

        await context.SaveChangesAsync(consumeContext.CancellationToken);

        logger.LogInformation("Successfully reserved timetable slot {TimeSlotId} for booking {BookingId}", timeSlot.Id, booking.Id);
    }
}

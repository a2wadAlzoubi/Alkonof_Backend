using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Exceptions;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Alkonof_Backend.Infrastructure.Consumers;

public class NotifyInReviewResponsibleBookingConsumer(ILogger<NotifyInReviewResponsibleBookingConsumer> logger, IApplicationDbContext context) : IConsumer<UpdateBookingStatusEvent>
{
    //, IEmailSender emailSender
    public async Task Consume(ConsumeContext<UpdateBookingStatusEvent> consumeContext)
    {
        var booking = await context.Booking
            .Include(b => b.Customer) // نحتاج إلى تضمين العميل للحصول على بريده الإلكتروني
            .FirstOrDefaultAsync(b => b.Id == consumeContext.Message.BookingId);

        if (booking is null || booking.Customer == null)
        {
            throw new NotFoundException(nameof(Booking), consumeContext.Message.BookingId.ToString());
        }

        booking.InReviewResponsibleBookingStatus();

        var customerEmail = booking.Customer.Email;

        if (string.IsNullOrWhiteSpace(customerEmail))
        {
            logger.LogError("[Email Notification] Customer for booking {BookingId} does not have an email address.", consumeContext.Message.BookingId);
            return;
        }

        var subject = $"Your Booking is Confirmed!";
        var body = $@"
            <html>
            <body>
                <h1>Hello {booking.Customer.Name},</h1>
                <p>  Your booking with ID <strong>{booking.Id}</strong></p>
                <p>Your appointment is delayed we will send a new booking confirmed soon in 2 hours maximum</p>
                <p>Thank you for using our service.</p>
                <br>
                <p>Alkonof Company</p>
            </body>
            </html>";

        //await emailSender.SendEmailAsync(customerEmail, subject, body);

        logger.LogInformation("[Email Notification] Email prepared and sent (via dummy sender) to {CustomerEmail} for booking {BookingId}.", customerEmail, booking.Id);

    }
}


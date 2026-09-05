using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Bookings.Book.Events;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Enums;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Alkonof_Backend.Infrastructure.Consumers;

public class NotifyCustomerOnApprovalConsumer : IConsumer<ResponsibleAnswerAssignedEvent>
{
    private readonly ILogger<NotifyCustomerOnApprovalConsumer> _logger;
    private readonly IApplicationDbContext _context;
    private readonly IEmailSender _emailSender;

    public NotifyCustomerOnApprovalConsumer(ILogger<NotifyCustomerOnApprovalConsumer> logger, IApplicationDbContext context, IEmailSender emailSender)
    {
        _logger = logger;
        _context = context;
        _emailSender = emailSender;
    }
    public async Task Consume(ConsumeContext<ResponsibleAnswerAssignedEvent> consumContext)
    {
        // نحن نهتم فقط بحالة الموافقة
        if (consumContext.Message.Decision != Decision.Approved)
        {
            return;
        }

        _logger.LogInformation("[Email Notification] Responsible approved booking {BookingId}. Preparing to send email to customer.", consumContext.Message.BookingId);

        var booking = await _context.Booking
            .Include(b => b.Customer) // نحتاج إلى تضمين العميل للحصول على بريده الإلكتروني
            .FirstOrDefaultAsync(b => b.Id == consumContext.Message.BookingId);

        if (booking == null || booking.Customer == null)
        {
            _logger.LogError("[Email Notification] Could not find booking or customer for booking ID: {BookingId}", consumContext.Message.BookingId);
            return;
        }

        var customerEmail = booking.Customer.Email;
        if (string.IsNullOrWhiteSpace(customerEmail))
        {
            _logger.LogError("[Email Notification] Customer for booking {BookingId} does not have an email address.", consumContext.Message.BookingId);
            return;
        }

        var subject = $"Your Booking is Confirmed!";
        var body = $@"
            <html>
            <body>
                <h1>Hello {booking.Customer.Name},</h1>
                <p>Great news! Your booking with ID <strong>{booking.Id}</strong> has been approved by the responsible party.</p>
                <p>Your appointment is confirmed for: <strong>{booking.ConfirmedAt:dddd, MMMM dd, yyyy 'at' HH:mm}</strong>.</p>
                <p>Please checkout your account to give an answer to the booking.</p>
                <p>https://alkonof.me</p>
                <p>Thank you for using our service.</p>
                <br>
                <p>Alkonof Company</p>
            </body>
            </html>";

        //await _emailSender.SendEmailAsync(customerEmail, subject, body);

        _logger.LogInformation("[Email Notification] Email prepared and sent (via dummy sender) to {CustomerEmail} for booking {BookingId}.", customerEmail, booking.Id);
    }
}

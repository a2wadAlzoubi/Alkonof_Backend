using Alkonof_Backend.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Resend;

namespace Alkonof_Backend.Infrastructure.Services;

public class ResendEmailSender : IEmailSender
{
    private readonly ILogger<ResendEmailSender> _logger;
    private readonly IResend _resendClient;
    private readonly string _fromAddress;

    public ResendEmailSender(ILogger<ResendEmailSender> logger, IResend resendClient, IOptions<ResendSettings> settings)
    {
        _logger = logger;
        _resendClient = resendClient;
        _fromAddress = settings.Value.FromAddress.Trim();
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        try
        {
            var normalizedTo = to.Trim();
            var message = new EmailMessage
            {
                From = _fromAddress,
                Subject = subject,
                HtmlBody = body
            };
            message.To.Add(normalizedTo);

            // Resend SDK v0.15.0 exposes EmailSendAsync on IResend interface
            // Returns ResendResponse<Guid> where Guid is the message ID
            var result = await _resendClient.EmailSendAsync(message);

            if (result.Success)
            {
                var messageId = result.Content;
                _logger.LogInformation("Email sent successfully to {To} via Resend. Message ID: {MessageId}", 
                    normalizedTo, 
                    messageId);
            }
            else
            {
                if (result.Exception != null)
                {
                    _logger.LogError("Failed to send email to {To} via Resend. Error: {ErrorMessage}", 
                        normalizedTo, 
                        result.Exception.Message);
                }
                else
                {
                    _logger.LogError("Failed to send email to {To} via Resend.", normalizedTo);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while sending email to {To} via Resend.", to);
            throw;
        }
    }
}

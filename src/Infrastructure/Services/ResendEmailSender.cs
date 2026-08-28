using Alkonof_Backend.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Resend;

namespace Alkonof_Backend.Infrastructure.Services;

public class ResendEmailSender : IEmailSender
{
    private readonly ILogger<ResendEmailSender> _logger;
    private readonly ResendSettings _settings;
    private readonly IResend _resendClient;

    public ResendEmailSender(ILogger<ResendEmailSender> logger, IOptions<ResendSettings> settings, IResend resendClient)
    {
        _logger = logger;
        _settings = settings.Value;
        _resendClient = resendClient;
    }

    public Task SendEmailAsync(string to, string subject, string body)
    {
        throw new NotImplementedException();
    }

    //public async Task SendEmailAsync(string to, string subject, string body)
    //{
    //    try
    //    {
    //        var result = await _resendClient.Emails.SendAsync(new EmailMessage
    //        {
    //            From = _settings.FromAddress,
    //            To = to,
    //            Subject = subject,
    //            HtmlBody = body
    //        });

    //        if (result.IsSuccess)
    //        {
    //            _logger.LogInformation("Email sent successfully to {To} via Resend. Message ID: {MessageId}", to, result.Id);
    //        }
    //        else
    //        {
    //            _logger.LogError("Failed to send email to {To} via Resend. Error: {ErrorName} - {ErrorMessage}", to, result.Error?.Name, result.Error?.Message);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "An unexpected error occurred while sending email to {To} via Resend.", to);
    //        throw;
    //    }
    //}
}

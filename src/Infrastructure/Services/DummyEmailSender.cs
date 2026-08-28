using Alkonof_Backend.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace Alkonof_Backend.Infrastructure.Services;

public class DummyEmailSender : IEmailSender
{
    private readonly ILogger<DummyEmailSender> _logger;

    public DummyEmailSender(ILogger<DummyEmailSender> logger)
    {
        _logger = logger;
    }

    public Task SendEmailAsync(string to, string subject, string body)
    {
        _logger.LogInformation("----- DUMMY EMAIL SENDER -----");
        _logger.LogInformation("Sending email to: {To}", to);
        _logger.LogInformation("Subject: {Subject}", subject);
        _logger.LogInformation("Body: {Body}", body);
        _logger.LogInformation("------------------------------");

        return Task.CompletedTask;
    }
}

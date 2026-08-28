using System.ComponentModel.DataAnnotations;

namespace Alkonof_Backend.Infrastructure.Services;

public class ResendSettings
{
    public const string SectionName = "Resend";

    [Required]
    public string ApiKey { get; init; } = null!;

    [Required]
    public string FromAddress { get; init; } = null!;
}

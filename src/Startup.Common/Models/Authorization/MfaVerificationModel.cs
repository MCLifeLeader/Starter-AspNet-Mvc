using System.ComponentModel.DataAnnotations;

namespace Startup.Common.Models.Authorization;

public class MfaVerificationModel
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [StringLength(6, MinimumLength = 6)]
    public string Code { get; set; } = string.Empty;
}
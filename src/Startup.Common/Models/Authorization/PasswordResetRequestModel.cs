using System.ComponentModel.DataAnnotations;

namespace Startup.Common.Models.Authorization;

public class PasswordResetRequestModel
{
    [Required]
    [EmailAddress]
    [MaxLength(256)]
    public string Email { get; set; } = string.Empty;
}
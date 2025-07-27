using System.ComponentModel.DataAnnotations;

namespace Startup.Common.Models.Authorization;

public class MfaLoginModel : UserLoginModel
{
    [Required]
    [StringLength(6, MinimumLength = 6)]
    public string MfaCode { get; set; } = string.Empty;
}
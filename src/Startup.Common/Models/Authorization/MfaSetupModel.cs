using System.ComponentModel.DataAnnotations;

namespace Startup.Common.Models.Authorization;

public class MfaSetupModel
{
    [Required]
    public string UserId { get; set; } = string.Empty;
    
    public string? SecretKey { get; set; }
    
    public string? QrCodeUri { get; set; }
}
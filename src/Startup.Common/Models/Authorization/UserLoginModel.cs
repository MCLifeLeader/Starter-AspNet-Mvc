using System.ComponentModel.DataAnnotations;

namespace Startup.Common.Models.Authorization;

public class UserLoginModel
{
    [MaxLength(256)]
    public string? Username { get; set; }
    [MaxLength(256)]
    public string? Password { get; set; }
    [MaxLength(256)]
    public string? DisplayName { get; set; }
    
    /// <summary>
    /// Indicates whether the user wants to be remembered for auto-login (1 week)
    /// </summary>
    public bool RememberMe { get; set; } = false;
}
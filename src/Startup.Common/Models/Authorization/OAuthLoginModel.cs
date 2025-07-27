using System.ComponentModel.DataAnnotations;

namespace Startup.Common.Models.Authorization;

/// <summary>
/// Model for OAuth login requests
/// </summary>
public class OAuthLoginModel
{
    /// <summary>
    /// The OAuth provider name (e.g., "Google", "Facebook", "Microsoft")
    /// </summary>
    [Required]
    public string Provider { get; set; } = null!;

    /// <summary>
    /// The user ID from the OAuth provider
    /// </summary>
    [Required]
    public string ProviderUserId { get; set; } = null!;

    /// <summary>
    /// The user's email address from the OAuth provider
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    /// <summary>
    /// The user's display name from the OAuth provider (optional)
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    /// Additional metadata from the OAuth provider (optional)
    /// </summary>
    public Dictionary<string, string>? Metadata { get; set; }
}
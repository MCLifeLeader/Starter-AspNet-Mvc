namespace Startup.Common.Models.Authorization;

/// <summary>
/// Model for OAuth user information
/// </summary>
public class OAuthUserInfo
{
    /// <summary>
    /// The OAuth provider name
    /// </summary>
    public string Provider { get; set; } = null!;

    /// <summary>
    /// The user ID from the OAuth provider
    /// </summary>
    public string ProviderUserId { get; set; } = null!;

    /// <summary>
    /// The user's email address
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// The user's display name
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    /// The user's first name
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// The user's last name
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// The user's profile picture URL
    /// </summary>
    public string? ProfilePictureUrl { get; set; }

    /// <summary>
    /// Whether the email is verified by the provider
    /// </summary>
    public bool EmailVerified { get; set; } = true;
}
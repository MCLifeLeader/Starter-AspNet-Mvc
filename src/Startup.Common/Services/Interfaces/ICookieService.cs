using Microsoft.AspNetCore.Http;

namespace Startup.Common.Services.Interfaces;

/// <summary>
/// Interface for cookie management service that handles multiple key/value pairs
/// </summary>
public interface ICookieService
{
    /// <summary>
    /// Sets a cookie value
    /// </summary>
    /// <param name="key">The cookie key</param>
    /// <param name="value">The cookie value</param>
    /// <param name="options">Optional cookie options</param>
    void SetCookie(string key, string value, CookieOptions? options = null);

    /// <summary>
    /// Gets a cookie value
    /// </summary>
    /// <param name="key">The cookie key</param>
    /// <returns>The cookie value or null if not found</returns>
    string? GetCookie(string key);

    /// <summary>
    /// Sets a boolean cookie value
    /// </summary>
    /// <param name="key">The cookie key</param>
    /// <param name="value">The boolean value</param>
    /// <param name="options">Optional cookie options</param>
    void SetBooleanCookie(string key, bool value, CookieOptions? options = null);

    /// <summary>
    /// Gets a boolean cookie value
    /// </summary>
    /// <param name="key">The cookie key</param>
    /// <param name="defaultValue">Default value if cookie is not found or invalid</param>
    /// <returns>The boolean value</returns>
    bool GetBooleanCookie(string key, bool defaultValue = false);

    /// <summary>
    /// Deletes a cookie
    /// </summary>
    /// <param name="key">The cookie key to delete</param>
    void DeleteCookie(string key);

    /// <summary>
    /// Sets an integer cookie value
    /// </summary>
    /// <param name="key">The cookie key</param>
    /// <param name="value">The integer value</param>
    /// <param name="options">Optional cookie options</param>
    void SetIntegerCookie(string key, int value, CookieOptions? options = null);

    /// <summary>
    /// Gets an integer cookie value
    /// </summary>
    /// <param name="key">The cookie key</param>
    /// <param name="defaultValue">Default value if cookie is not found or invalid</param>
    /// <returns>The integer value</returns>
    int GetIntegerCookie(string key, int defaultValue = 0);

    /// <summary>
    /// Sets a Base64 encoded object cookie value
    /// </summary>
    /// <param name="key">The cookie key</param>
    /// <param name="value">The object to encode</param>
    /// <param name="options">Optional cookie options</param>
    void SetObjectCookie<T>(string key, T value, CookieOptions? options = null);

    /// <summary>
    /// Gets a Base64 encoded object cookie value
    /// </summary>
    /// <param name="key">The cookie key</param>
    /// <param name="defaultValue">Default value if cookie is not found or invalid</param>
    /// <returns>The object value</returns>
    T? GetObjectCookie<T>(string key, T? defaultValue = default);
}
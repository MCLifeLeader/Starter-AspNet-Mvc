namespace Startup.Common.Services.Interfaces;

/// <summary>
/// Interface for query string handling service
/// </summary>
public interface IQueryStringService
{
    /// <summary>
    /// Gets a query string value
    /// </summary>
    /// <param name="key">The query string key</param>
    /// <returns>The query string value or null if not found</returns>
    string? GetQueryString(string key);

    /// <summary>
    /// Gets a boolean query string value
    /// </summary>
    /// <param name="key">The query string key</param>
    /// <param name="defaultValue">Default value if query string is not found or invalid</param>
    /// <returns>The boolean value</returns>
    bool GetBooleanQueryString(string key, bool defaultValue = false);

    /// <summary>
    /// Checks if a query string parameter exists
    /// </summary>
    /// <param name="key">The query string key</param>
    /// <returns>True if the parameter exists</returns>
    bool HasQueryString(string key);

    /// <summary>
    /// Gets an integer query string value
    /// </summary>
    /// <param name="key">The query string key</param>
    /// <param name="defaultValue">Default value if query string is not found or invalid</param>
    /// <returns>The integer value</returns>
    int GetIntegerQueryString(string key, int defaultValue = 0);
}
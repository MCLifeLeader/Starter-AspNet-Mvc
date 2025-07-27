using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Startup.Common.Services.Interfaces;

namespace Startup.Common.Services;

/// <summary>
/// Query string handling service
/// </summary>
public class QueryStringService : IQueryStringService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<QueryStringService> _logger;

    public QueryStringService(ILogger<QueryStringService> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc />
    public string? GetQueryString(string key)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(GetQueryString));
        }

        return _httpContextAccessor.HttpContext?.Request.Query[key].FirstOrDefault();
    }

    /// <inheritdoc />
    public bool GetBooleanQueryString(string key, bool defaultValue = false)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(GetBooleanQueryString));
        }

        var queryValue = GetQueryString(key);
        
        if (string.IsNullOrEmpty(queryValue))
        {
            return defaultValue;
        }

        // Handle common boolean representations
        if (string.Equals(queryValue, "true", StringComparison.OrdinalIgnoreCase) || 
            string.Equals(queryValue, "1", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        if (string.Equals(queryValue, "false", StringComparison.OrdinalIgnoreCase) || 
            string.Equals(queryValue, "0", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }
        return defaultValue;
    }

    /// <inheritdoc />
    public bool HasQueryString(string key)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(HasQueryString));
        }

        return _httpContextAccessor.HttpContext?.Request.Query.ContainsKey(key) ?? false;
    }

    /// <inheritdoc />
    public int GetIntegerQueryString(string key, int defaultValue = 0)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(GetIntegerQueryString));
        }

        var queryValue = GetQueryString(key);
        
        if (string.IsNullOrEmpty(queryValue))
        {
            return defaultValue;
        }

        return int.TryParse(queryValue, out var result) ? result : defaultValue;
    }
}
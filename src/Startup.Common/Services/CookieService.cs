using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Startup.Common.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace Startup.Common.Services;

/// <summary>
/// Cookie management service that handles multiple key/value pairs
/// </summary>
public class CookieService : ICookieService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<CookieService> _logger;

    public CookieService(ILogger<CookieService> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc />
    public void SetCookie(string key, string value, CookieOptions? options = null)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(SetCookie));
        }

        var cookieOptions = options ?? new CookieOptions
        {
            Path = "/",
            Secure = true,
            SameSite = SameSiteMode.Strict,
            HttpOnly = false, // Allow JavaScript access if needed
            Expires = DateTimeOffset.UtcNow.AddYears(1) // Default 1 year expiry
        };

        _httpContextAccessor.HttpContext?.Response.Cookies.Append(key, value, cookieOptions);
    }

    /// <inheritdoc />
    public string? GetCookie(string key)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(GetCookie));
        }

        return _httpContextAccessor.HttpContext?.Request.Cookies[key];
    }

    /// <inheritdoc />
    public void SetBooleanCookie(string key, bool value, CookieOptions? options = null)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(SetBooleanCookie));
        }

        SetCookie(key, value.ToString().ToLowerInvariant(), options);
    }

    /// <inheritdoc />
    public bool GetBooleanCookie(string key, bool defaultValue = false)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(GetBooleanCookie));
        }

        var cookieValue = GetCookie(key);
        
        if (string.IsNullOrEmpty(cookieValue))
        {
            return defaultValue;
        }

        return bool.TryParse(cookieValue, out var result) ? result : defaultValue;
    }

    /// <inheritdoc />
    public void DeleteCookie(string key)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(DeleteCookie));
        }

        var cookieOptions = new CookieOptions
        {
            Path = "/"
        };

        _httpContextAccessor.HttpContext?.Response.Cookies.Delete(key, cookieOptions);
    }

    /// <inheritdoc />
    public void SetIntegerCookie(string key, int value, CookieOptions? options = null)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(SetIntegerCookie));
        }

        SetCookie(key, value.ToString(), options);
    }

    /// <inheritdoc />
    public int GetIntegerCookie(string key, int defaultValue = 0)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(GetIntegerCookie));
        }

        var cookieValue = GetCookie(key);
        
        if (string.IsNullOrEmpty(cookieValue))
        {
            return defaultValue;
        }

        return int.TryParse(cookieValue, out var result) ? result : defaultValue;
    }

    /// <inheritdoc />
    public void SetObjectCookie<T>(string key, T value, CookieOptions? options = null)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(SetObjectCookie));
        }

        if (value is null)
        {
            DeleteCookie(key);
            return;
        }

        var jsonString = JsonSerializer.Serialize(value);
        var base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonString));
        SetCookie(key, base64String, options);
    }

    /// <inheritdoc />
    public T? GetObjectCookie<T>(string key, T? defaultValue = default)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("'{Class}.{Method}' called", GetType().Name, nameof(GetObjectCookie));
        }

        var cookieValue = GetCookie(key);
        
        if (string.IsNullOrEmpty(cookieValue))
        {
            return defaultValue;
        }

        try
        {
            var jsonBytes = Convert.FromBase64String(cookieValue);
            var jsonString = Encoding.UTF8.GetString(jsonBytes);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to deserialize cookie value for key '{Key}'", key);
            return defaultValue;
        }
    }
}
using Startup.Common.Helpers.Data;

namespace Starter.AspNet.MVC.Models.ApplicationSettings;

public record Opentelemetry
{
    public string Endpoint { get; set; } = default!;

    [SensitiveData]
    public string ApiKey { get; set; } = default!;
}
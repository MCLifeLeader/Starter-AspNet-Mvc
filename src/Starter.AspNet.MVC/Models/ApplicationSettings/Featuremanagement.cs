namespace Starter.AspNet.MVC.Models.ApplicationSettings;

public record Featuremanagement
{
    public bool OpenTelemetryEnabled { get; set; }
    public bool InformationEndpoints { get; set; }
    public bool SqlDebugger { get; set; }
    public bool DisplayConfiguration { get; set; }
    public bool HealthCheckService { get; set; }
}
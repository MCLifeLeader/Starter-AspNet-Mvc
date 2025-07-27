namespace Starter.AspNet.MVC.Models.ApplicationSettings;

public record HealthCheckEndpoint
{
    public string OpenAi { get; set; } = default!;
    public int TimeoutInSeconds { get; set; }
}
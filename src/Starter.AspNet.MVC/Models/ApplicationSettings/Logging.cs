namespace Starter.AspNet.MVC.Models.ApplicationSettings;

public record Logging
{
    public Loglevel LogLevel { get; set; } = default!;
}
using Starter.AspNet.MVC.Data;
using Starter.AspNet.MVC.Models.ApplicationSettings;
using Starter.AspNet.MVC.Services.Interfaces;

namespace Starter.AspNet.MVC.Services.DependencyInjection;

public static class ServicesResolver
{
    public static void RegisterDependencies(IServiceCollection service, AppSettings appSettings)
    {
        service.AddSingleton<WeatherForecastService>();
        service.AddTransient<IInfoService, InfoService>();
    }
}
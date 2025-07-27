using Starter.AspNet.MVC.Models.ApplicationSettings;

namespace Starter.AspNet.MVC.Factories.DependencyInjection;

public static class FactoriesResolver
{
    public static void RegisterDependencies(IServiceCollection service, AppSettings appSettings)
    {
        //service.AddScoped<IFactory, Factory>();
    }
}
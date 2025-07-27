using Microsoft.Extensions.Caching.Memory;
using Starter.AspNet.MVC.Models.ApplicationSettings;

namespace Starter.AspNet.MVC.Helpers.DependencyInjection;

public static class HelpersResolver
{
    public static void RegisterDependencies(IServiceCollection service, AppSettings appSettings)
    {
        service.AddSingleton<MemoryCache>();
    }
}
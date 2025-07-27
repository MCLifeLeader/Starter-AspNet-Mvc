using Starter.AspNet.MVC.Models.ApplicationSettings;
using Startup.Common.Connection;
using Startup.Common.Connection.Interfaces;

namespace Starter.AspNet.MVC.Connection.DependencyInjection;

public static class ConnectionResolver
{
    public static void RegisterDependencies(IServiceCollection service, AppSettings appSettings)
    {
        service.AddScoped<IHttpClientWrapper, HttpClientWrapper>();
    }
}
using Microsoft.Extensions.DependencyInjection;
using Startup.Business.Services;
using Startup.Business.Services.Interfaces;

namespace Startup.Business.DependencyInjection;

public static class BusinessServicesResolver
{
    public static void RegisterDependencies(IServiceCollection services)
    {
        //services.AddAzureClients(builder =>
        //{
        //    builder.AddBlobServiceClient(appSettings.BlobStorageConnection).WithName(BlobStorageClientNames.STARTUP_BLOB);
        //});

        #region Repositories
        //services.AddTransient<IBlobStorageRepository, BlobStorageRepository>();
        #endregion

        #region Services
        //services.AddTransient<IBlobService, BlobService>();
        services.AddTransient<IAuthenticatorService, AuthenticatorService>();

        #endregion
    }
}
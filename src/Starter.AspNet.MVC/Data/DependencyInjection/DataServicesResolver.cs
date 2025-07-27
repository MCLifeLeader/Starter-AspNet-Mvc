using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Starter.AspNet.MVC.Models.ApplicationSettings;
using Starter.AspNet.MVC.Repository.Http.Endpoints;
using Starter.AspNet.MVC.Repository.Http.Endpoints.Interfaces;

namespace Starter.AspNet.MVC.Data.DependencyInjection;

public static class DataServicesResolver
{
    public static void RegisterDependencies(IServiceCollection service, AppSettings appSettings)
    {
        service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(appSettings.ConnectionStrings.DefaultConnection));
        service.AddDatabaseDeveloperPageExceptionFilter();
        service.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

        #region Http Repositories

        service.AddTransient<IInfoPageCache, InfoPageCache>();
        service.AddScoped<IInfoPageRepository, InfoPageRepository>();

        #endregion
    }
}
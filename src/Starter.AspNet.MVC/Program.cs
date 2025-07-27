using Starter.AspNet.MVC;
using Starter.AspNet.MVC.Models.ApplicationSettings;

WebApplication.CreateBuilder(args)
    .RegisterServices(out AppSettings? appSettings)
    .Build()
    .SetupMiddleware(appSettings)
    .Run();
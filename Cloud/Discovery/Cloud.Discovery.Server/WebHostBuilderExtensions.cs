using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using System.Linq;
using Cloud.Discovery.Application;
using Cloud.Discovery.Infrastructure;
using Cloud.Shared.Web;
using Microsoft.AspNetCore.Builder;
using Cloud.Shared.Web.Swagger;

namespace Cloud.Discovery.Server
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder EnableDiscoveryServer(this IWebHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                RegisterDependencyInjections(services);
                RegisterAppsController(services);
            });

            builder.Configure(app =>
            {
                app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            });

            return builder;
        }

        private static void RegisterAppsController(IServiceCollection services)
        {
            var controllerAssembly = typeof(Controllers.AppsController).Assembly;
            services.AddMvc().AddApplicationPart(controllerAssembly).AddControllersAsServices();
        }

        private static void RegisterDependencyInjections(IServiceCollection services)
        {
            services.AddSingleton<IInstanceService, InstanceService>();
            services.AddSingleton<IInstanceRepository, InstanceRepository>();
        }
    }
}

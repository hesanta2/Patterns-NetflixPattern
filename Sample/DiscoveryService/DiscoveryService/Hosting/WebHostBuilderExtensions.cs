using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using System.Linq;

namespace DiscoveryService.Hosting
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder AddDiscoveryServiceConfiguration(this IWebHostBuilder builder, string[] args)
        {
            //builder.AddDiscoveryMicroServiceConfiguration(args);

            builder.ConfigureServices(services =>
            {
                //services.AddSingleton<IDiscoveryService, Application.DiscoveryService>();
                //services.AddSingleton<IDiscoveryRepository, DiscoveryRepository>();

                //var discoveryService = services.BuildServiceProvider().GetRequiredService<IDiscoveryService>();
                //var hostEndpoints = builder.GetSetting(WebHostDefaults.ServerUrlsKey);
                //var endpoints = hostEndpoints.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                //discoveryService.Add(new DiscoveredInstance(Assembly.GetEntryAssembly().GetName().Name, endpoints));
            });

            return builder;
        }

    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace ConfigServiceClient.Hosting
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder AddConfigService(this IWebHostBuilder builder, double configurationLifetimmeMinutes = 5, int retryCount = 6, double exponientialBackoff = 2)
        {
            builder.ConfigureServices(services =>
            {
                services.AddHttpClient<IConfigurationClient, ConfigurationClient>()
                        .SetHandlerLifetime(TimeSpan.FromMinutes(configurationLifetimmeMinutes))
                        .AddPolicyHandler(GetRetryPolicy(retryCount, exponientialBackoff));

                var configurationClient = services.BuildServiceProvider().GetService<IConfigurationClient>();
                var serviceName = Assembly.GetEntryAssembly().GetName().Name;
                var configuration = configurationClient.Get(serviceName).Result;
            });

            return builder;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount, double exponientialBackoff)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(exponientialBackoff, retryAttempt)));
        }
    }
}

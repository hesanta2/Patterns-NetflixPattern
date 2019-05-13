using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
                services.AddHttpClient<IConfigurationClient, ConfigurationClient>
                (
                    (httpClient) => httpClient.BaseAddress = new Uri("http://localhost:5010")
                )
                .SetHandlerLifetime(TimeSpan.FromMinutes(configurationLifetimmeMinutes))
                .AddPolicyHandler(GetRetryPolicy(retryCount, exponientialBackoff));

                var serviceProvider = services.BuildServiceProvider();
                var logger = serviceProvider.GetService<ILogger<ConfigurationClient>>();
                var configurationClient = serviceProvider.GetService<IConfigurationClient>();
                var serviceName = Assembly.GetEntryAssembly().GetName().Name;

                try
                {
                    var configuration = configurationClient.Get(serviceName).Result;
                }
                catch (Exception ex)
                {
                    var message = $"Configuration service is not avaliable. Service '{serviceName}' can not start.";
                    logger.LogError(message);
                    throw new InvalidProgramException(message, ex);
                }
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

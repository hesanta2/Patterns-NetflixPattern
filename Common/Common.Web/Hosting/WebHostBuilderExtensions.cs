using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ConfigServiceClient.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace Common.Web.Hosting
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder AddServiceConfiguration(this IWebHostBuilder builder, string[] args, double configurationLifetimmeMinutes = 5, int retryCount = 6, double exponientialBackoff = 2)
        {
            if (args.Length > 0) builder.UseUrls(args);

            var endpoints = builder.GetSetting(WebHostDefaults.ServerUrlsKey);

            builder.AddConfigService(configurationLifetimmeMinutes, retryCount, exponientialBackoff);

            return builder;
        }

    }
}

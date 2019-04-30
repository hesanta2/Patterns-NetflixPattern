using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Web.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            SwaggerConfig.ConfigServices(services);

            return services;
        }

        public static IApplicationBuilder AddSwagger(this IApplicationBuilder app)
        {
            SwaggerConfig.ConfigureApplication(app);

            return app;
        }
    }
}

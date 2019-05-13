using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;
using System.Buffers;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Cloud.Shared.Web.Swagger
{
    public static class SwaggerConfig
    {

        public static void ConfigServices(IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                //options.OutputFormatters.Clear();
                //options.OutputFormatters.Add(new JsonOutputFormatter(JsonSerializerSettingsProvider.CreateSerializerSettings(), ArrayPool<Char>.Shared));

                options.OutputFormatters.Where(f => !f.GetType().Equals(typeof(JsonOutputFormatter))).ToList().ForEach(f => options.OutputFormatters.Remove(f));
                options.InputFormatters.Where(f => !f.GetType().Equals(typeof(JsonInputFormatter))).ToList().ForEach(f => options.InputFormatters.Remove(f));
                //options.InputFormatters.Clear();
                //options.InputFormatters.Add(new JsonInputFormatter(JsonSerializerSettingsProvider.CreateSerializerSettings(), ArrayPool<Char>.Shared));

            });


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = Assembly.GetEntryAssembly().GetName().Name, Version = "v1" });
            });
        }

        public static void ConfigureApplication(IApplicationBuilder app, string routePrefix = "swagger")
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Assembly.GetEntryAssembly().GetName().Name);
                c.RoutePrefix = routePrefix;
            });
        }

    }
}

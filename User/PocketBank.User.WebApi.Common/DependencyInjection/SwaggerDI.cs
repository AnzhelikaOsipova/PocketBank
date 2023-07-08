using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PocketBank.User.WebApi.Common.Options;
using System.Reflection;

namespace PocketBank.User.WebApi.Common.DependencyInjection
{
    public static class SwaggerDI
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, AssemblyNamesOptions options)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PocketBank API",
                    Description = "Testing API for demonstrations",
                    Version = "v1"
                });

                var xmlDocModelsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlDocModelsFilePath = Path.Combine(AppContext.BaseDirectory, xmlDocModelsFile);
                opt.IncludeXmlComments(xmlDocModelsFilePath);

                var xmlDocEndpointsFile = $"{options.AssemblyStartupProjectName}.xml";
                var xmlDocEndpointsFilePath = Path.Combine(AppContext.BaseDirectory, xmlDocEndpointsFile);
                opt.IncludeXmlComments(xmlDocEndpointsFilePath);

            });

            return services;
        }
    }
}

using PocketBank.User.WebApi.Common.DependencyInjection;
using PocketBank.User.WebApi.Common.Options;

namespace PocketBank.User.WebApi.DependencyInjection
{
    public static class WebApiDI
    {
        public static void AddWebApi(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDtoMapping();
            services.AddValidation();
            services.AddSwagger(configuration.GetSection("AssemblyNames").Get<AssemblyNamesOptions>()!);
        }
    }
}

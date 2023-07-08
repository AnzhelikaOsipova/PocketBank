using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PocketBank.User.WebApi.Common.DependencyInjection
{
    public static class DtoMappingDI
    {
        public static IServiceCollection AddDtoMapping(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

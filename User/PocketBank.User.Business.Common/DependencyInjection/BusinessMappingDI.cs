using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PocketBank.User.Business.Common.DependencyInjection
{
    public static class BusinessMappingDI
    {
        public static IServiceCollection AddBusinessMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

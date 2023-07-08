using Microsoft.Extensions.DependencyInjection;
using PocketBank.User.Business.Interfaces;
using PocketBank.User.Business.Services;

namespace PocketBank.User.Business.DependencyInjection
{
    public static class BusinessServicesDI
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IClientService, ClientService>();

            return services;
        }
    }
}

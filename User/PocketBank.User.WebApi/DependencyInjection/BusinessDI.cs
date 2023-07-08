using PocketBank.User.Business.Common.DependencyInjection;
using PocketBank.User.Business.DependencyInjection;

namespace PocketBank.User.WebApi.DependencyInjection
{
    public static class BusinessDI
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddBusinessMapping();
            services.AddServices();
        }
    }
}

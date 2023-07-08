using static PocketBank.User.DataAccess.DependencyInjection.DataAccessDI;

namespace PocketBank.User.WebApi.DependencyInjection
{
    public static class DataAccessDI
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration)
                .AddRepositories();
        }
    }
}

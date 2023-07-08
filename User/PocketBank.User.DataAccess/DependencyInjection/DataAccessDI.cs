using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PocketBank.User.DataAccess.Common.Constants;
using PocketBank.User.DataAccess.Common.Entities;
using PocketBank.User.DataAccess.Common.Options;
using PocketBank.User.DataAccess.Common.Repositories;
using PocketBank.User.DataAccess.Repositories;
using PocketBank.User.DataAccess.Seed;

namespace PocketBank.User.DataAccess.DependencyInjection
{
    public static class DataAccessDI
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var dbSection = configuration.GetSection(Constants.OptionNames.DbOptionsName);            
            services.Configure<DbOptions>(dbSection);
            var options = dbSection.Get<DbOptions>()!;

            services.AddDbContext<UserDbContext>(opt => opt.UseNpgsql(options.ConnectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddScoped<DbContext, UserDbContext>();

            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DbContext>();            

            if (options.RecreateDatabase)
            {
                context.Database.EnsureDeleted();
            }

            if (options.UseAutoMigrations)
            {
                if (context.Database.GetMigrations().Any())
                {
                    context.Database.Migrate();
                }
                else 
                {
                    context.Database.EnsureCreated();
                }
            }

            if (options.UseAutoSeed)
            {
                var seeder = new FileSeeder(options, context);
                seeder.Seed();
            }

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<ClientEntity>, ClientRepository>();

            return services;
        }
    }
}

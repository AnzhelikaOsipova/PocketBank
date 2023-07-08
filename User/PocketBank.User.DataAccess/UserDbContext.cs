using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PocketBank.User.DataAccess.Common.Entities;
using PocketBank.User.DataAccess.Common.Options;
using System.Reflection;

namespace PocketBank.User.DataAccess
{
    public class UserDbContext : DbContext
    {
        private readonly DbOptions _dbOptions;

        public DbSet<ClientEntity> Clients { get; set; }

        public UserDbContext(DbContextOptions dbContextOptions, IOptions<DbOptions> dbOptions)
            : base(dbContextOptions) 
        {
            _dbOptions = dbOptions.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load(_dbOptions.AssemblyWithEntitiesName));
        }
    }
}

using PocketBank.User.DataAccess.Common.Options;
using PocketBank.User.DataAccess.Common.Exceptions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace PocketBank.User.DataAccess.Seed
{
    public class FileSeeder
    {
        private readonly DbOptions _options;
        private readonly DbContext _context;

        public FileSeeder(DbOptions options, DbContext context)
        {
            _options = options;
            _context = context;
        }

        public void Seed()
        {
            try
            {
                var currentAssembly = Assembly.GetExecutingAssembly();
                var entityAssembly = Assembly.Load(_options.AssemblyWithEntitiesName);
                var path = Path.GetDirectoryName(currentAssembly.Location) + _options.DemoDataRelativePath;

                if (!Directory.Exists(path)) throw new SeedDirectoryNotExistsException(path);
                var files = Directory.EnumerateFiles(path, "*.json");

                var entityNames = entityAssembly.GetTypes().Select(t => t.Name).Where(n => n.EndsWith("Entity"));
                var seedFiles = files.Where(file => entityNames.Contains(Path.GetFileNameWithoutExtension(file)));

                foreach (var seedFile in seedFiles)
                {
                    var entityType = entityAssembly.GetTypes().First(t => t.Name == Path.GetFileNameWithoutExtension(seedFile));
                    var jsonData = File.ReadAllText(seedFile);

                    var addMethod = GetType().GetMethod("AddToContext", BindingFlags.NonPublic | BindingFlags.Instance)!.MakeGenericMethod(entityType);
                    addMethod.Invoke(this, new[] { jsonData });
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new SeedFailedException(ex, $"Failed saving data to the database.");
            }
        }

        private void AddToContext<TEntity>(string jsonData) where TEntity : class
        {
            if (!_context.Set<TEntity>().Any())
            {
                var data = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(jsonData)!;
                _context.AddRange(data);
            }
        }
    }
}

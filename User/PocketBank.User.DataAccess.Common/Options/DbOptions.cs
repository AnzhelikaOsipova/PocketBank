namespace PocketBank.User.DataAccess.Common.Options
{
    public class DbOptions
    {
        public string ConnectionString { get; set; }
        public bool UseAutoMigrations { get; set; }
        public bool UseAutoSeed { get; set; }
        public bool RecreateDatabase { get; set; }
        public string DemoDataRelativePath { get; set; }
        public string AssemblyWithEntitiesName { get; set; }
    }
}

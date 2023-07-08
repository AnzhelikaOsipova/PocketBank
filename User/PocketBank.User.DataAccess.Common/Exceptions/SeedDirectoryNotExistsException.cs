namespace PocketBank.User.DataAccess.Common.Exceptions
{
    public class SeedDirectoryNotExistsException : Exception
    {
        public SeedDirectoryNotExistsException(string path)
        : base($"A directory with the path \"{path}\" does not exist") { }
    }
}

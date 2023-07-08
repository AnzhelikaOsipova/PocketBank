namespace PocketBank.User.DataAccess.Common.Exceptions
{
    public class SeedFailedException : Exception
    {
        public SeedFailedException(Exception ex, string message) : 
            base(message, ex) { }
    }
}

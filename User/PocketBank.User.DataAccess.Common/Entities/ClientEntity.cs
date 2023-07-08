namespace PocketBank.User.DataAccess.Common.Entities
{
    public class ClientEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string PassportNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

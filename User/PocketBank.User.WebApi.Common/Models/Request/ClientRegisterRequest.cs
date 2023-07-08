namespace PocketBank.User.WebApi.Common.Models.Request
{
    public class ClientRegisterRequest
    {
        /// <summary>
        /// Client's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Client's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Client's middle name, if exists
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Client's passport number
        /// </summary>
        public string PassportNumber { get; set; }

        /// <summary>
        /// Client's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Client's password
        /// </summary>
        public string Password { get; set; }
    }
}

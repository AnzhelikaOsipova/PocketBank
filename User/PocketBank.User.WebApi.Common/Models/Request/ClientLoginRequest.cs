namespace PocketBank.User.WebApi.Common.Models.Request
{
    public class ClientLoginRequest
    {
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

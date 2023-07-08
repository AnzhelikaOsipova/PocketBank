using Microsoft.AspNetCore.Mvc;

namespace PocketBank.User.WebApi.Common.Models.Request
{
    public class ClientIdRequest
    {
        /// <summary>
        /// Client's id from database
        /// </summary>
        [FromQuery]
        public Guid Id { get; set; }
    }
}

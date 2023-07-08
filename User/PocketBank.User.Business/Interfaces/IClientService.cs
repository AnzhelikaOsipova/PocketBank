using PocketBank.User.Business.Common.Models;
using PocketBank.User.Business.Common.Models.ServiceResult;

namespace PocketBank.User.Business.Interfaces
{
    public interface IClientService
    {
        public Task<ClientPartialInfo> GetClientInfoAsync(Guid clientId);
        public Task AddNewClientAsync(ClientBusiness client);
        public Task<ClientAuth> LoginAsync(string email, string password);
    }
}

using AutoMapper;
using PocketBank.User.Business.Common.Models;
using PocketBank.User.Business.Common.Models.ServiceResult;
using PocketBank.User.Business.Interfaces;
using PocketBank.User.DataAccess.Common.Entities;
using PocketBank.User.DataAccess.Common.Repositories;
using PocketBank.User.DataAccess.Specifications.Client;

namespace PocketBank.User.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ClientEntity> _clientRepository;

        public ClientService(IMapper mapper, IRepository<ClientEntity> clientRepository) 
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<ClientPartialInfo> GetClientInfoAsync(Guid clientId)
        {
            var client = await _clientRepository.FindByIdAsync(clientId);

            return _mapper.Map<ClientPartialInfo>(client);
        }

        public async Task AddNewClientAsync(ClientBusiness client)
        {
            var clientEntity = _mapper.Map<ClientEntity>(client);
            await _clientRepository.CreateAsync(clientEntity);
        }

        public async Task<ClientAuth> LoginAsync(string email, string password)
        {
            var specification = new ClientByEmail(email);
            var clientEntity = (await _clientRepository.FindWithSpecificationAsync(specification))
                .FirstOrDefault();
            var client = _mapper.Map<ClientBusiness>(clientEntity);
            if ((client is null) || (client.Password != password)) return new ClientAuth() { IsSucceed = false };
            
            return new ClientAuth() { IsSucceed = true, Id = client.Id };
        }
    }
}

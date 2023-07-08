using AutoMapper;
using PocketBank.User.Business.Common.Models;
using PocketBank.User.Business.Common.Models.ServiceResult;
using PocketBank.User.DataAccess.Common.Entities;

namespace PocketBank.User.Business.Common.Mapping
{
    public class ClientModelMapper : Profile
    {
        public ClientModelMapper() 
        {
            CreateMap<ClientEntity, ClientBusiness>().ReverseMap();
            CreateMap<ClientEntity, ClientPartialInfo>();
        }
    }
}

using AutoMapper;
using PocketBank.User.Business.Common.Models;
using PocketBank.User.Business.Common.Models.ServiceResult;
using PocketBank.User.WebApi.Common.Models.Request;
using PocketBank.User.WebApi.Common.Models.Response;

namespace PocketBank.User.WebApi.Common.Mapping
{
    public class ClientModelMapper : Profile
    {
        public ClientModelMapper() 
        {
            CreateMap<ClientPartialInfo, ClientPartialInfoResponse>();
            CreateMap<ClientRegisterRequest, ClientBusiness>();
        }
    }
}

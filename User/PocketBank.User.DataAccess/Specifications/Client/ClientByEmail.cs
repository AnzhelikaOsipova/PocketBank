using PocketBank.User.DataAccess.Common.Specifications;
using PocketBank.User.DataAccess.Common.Entities;

namespace PocketBank.User.DataAccess.Specifications.Client
{
    public class ClientByEmail : SpecificationBase<ClientEntity>
    {
        public ClientByEmail(string email)
        : base(c => c.Email == email) { }
    }
}

using Microsoft.EntityFrameworkCore;
using PocketBank.User.DataAccess.Common.Entities;
using PocketBank.User.DataAccess.Common.Repositories;

namespace PocketBank.User.DataAccess.Repositories
{
    public class ClientRepository : RepositoryBase<ClientEntity>
    {
        public ClientRepository(DbContext context) : base(context) { }
    }
}

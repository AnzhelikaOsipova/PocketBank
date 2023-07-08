using Microsoft.EntityFrameworkCore;
using PocketBank.User.DataAccess.Common.Specifications;

namespace PocketBank.User.DataAccess.Common.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<TEntity?> FindByIdAsync(object id);
        public Task CreateAsync(TEntity item);
        public Task CreateRangeAsync(TEntity[] items);
        public Task UpdateAsync(TEntity item);
        public Task UpdateRangeAsync(TEntity[] items);
        public Task DeleteAsync(TEntity item);
        public Task DeleteRangeAsync(TEntity[] items);
        public Task<IEnumerable<TEntity>> FindWithSpecificationAsync(ISpecification<TEntity> specification, bool asNoTracking = true);
    }
}

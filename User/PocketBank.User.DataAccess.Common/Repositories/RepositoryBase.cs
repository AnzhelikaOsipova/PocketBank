using Microsoft.EntityFrameworkCore;
using PocketBank.User.DataAccess.Common.Exceptions;
using PocketBank.User.DataAccess.Common.Specifications;

namespace PocketBank.User.DataAccess.Common.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        public RepositoryBase(DbContext context) 
        {
            _context = context;
        }

        public async Task<TEntity?> FindByIdAsync(object id)
        {
            try
            {
                return await _context.FindAsync<TEntity>(id);
            }
            catch (Exception ex)
            {
                throw new RepositoryDatabaseException(ex, Enums.OperationType.Read, nameof(TEntity), ("id: ", id.ToString() ?? "null"));
            }
        }

        public async Task CreateAsync(TEntity item)
        {
            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryDatabaseException(ex, Enums.OperationType.Create, nameof(TEntity));
            }
        }

        public async Task CreateRangeAsync(TEntity[] items)
        {
            try
            {
                _context.AddRange(items);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryDatabaseException(ex, Enums.OperationType.Create, nameof(TEntity));
            }
        }

        public async Task UpdateAsync(TEntity item)
        {
            try
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryDatabaseException(ex, Enums.OperationType.Update, nameof(TEntity));
            }
        }

        public async Task UpdateRangeAsync(TEntity[] items)
        {
            try
            {
                _context.UpdateRange(items);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryDatabaseException(ex, Enums.OperationType.Update, nameof(TEntity));
            }
        }

        public async Task DeleteAsync(TEntity item)
        {
            try
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryDatabaseException(ex, Enums.OperationType.Delete, nameof(TEntity));
            }
        }

        public async Task DeleteRangeAsync(TEntity[] items)
        {
            try
            {
                _context.RemoveRange(items);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryDatabaseException(ex, Enums.OperationType.Delete, nameof(TEntity));
            }
        }

        public async Task<IEnumerable<TEntity>> FindWithSpecificationAsync(ISpecification<TEntity> specification, bool asNoTracking = true)
        {
            try
            {
                var query = _context.Set<TEntity>().AsQueryable();

                if (asNoTracking) query = query.AsNoTracking();
                if (specification.Condition is not null) query = query.Where(specification.Condition);
                if (specification.OrderBy is not null) query = query.OrderBy(specification.OrderBy);
                if (specification.OrderByDescending is not null) query = query.OrderByDescending(specification.OrderByDescending);
                query = specification.Includes.Aggregate(query, (current, include) => include(current));

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryDatabaseException(ex, Enums.OperationType.Read, nameof(TEntity), ("specification: ", nameof(specification)));
            }
        }
    }
}

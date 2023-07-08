using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace PocketBank.User.DataAccess.Common.Specifications
{
    public interface ISpecification<TEntity>
    {
        public Expression<Func<TEntity, bool>> Condition { get; }
        public Expression<Func<TEntity, object>> OrderBy { get; }
        public Expression<Func<TEntity, object>> OrderByDescending { get; }
        public List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> Includes { get; }
    }
}

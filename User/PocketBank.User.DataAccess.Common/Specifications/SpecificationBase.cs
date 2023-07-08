using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace PocketBank.User.DataAccess.Common.Specifications
{
    public class SpecificationBase<TEntity> : ISpecification<TEntity>
    {
        public Expression<Func<TEntity, bool>> Condition { get; }
        public Expression<Func<TEntity, object>> OrderBy { get; private set; }
        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }
        public List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> Includes { get; } =
            new List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>();

        public SpecificationBase() { }

        public SpecificationBase(Expression<Func<TEntity, bool>> condition)
            => Condition = condition;

        public SpecificationBase(
            Expression<Func<TEntity, bool>> condition, 
            Expression<Func<TEntity, object>> orderBy, 
            bool orderByDesc = false)
        {
            Condition = condition;
            if (orderByDesc)
            {
                OrderByDescending = orderBy;
            }
            else
            {
                OrderBy = orderBy;
            }
        }

        protected void AddInclude(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            Includes.Add(include);
        }
    }
}

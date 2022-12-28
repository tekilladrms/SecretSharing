using SecretSharing.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Domain.Repositories
{
    public abstract class Specification<TEntity> 
        where TEntity : Entity
    {
        public Expression<Func<TEntity, bool>> Criteria { get; }

        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();

        protected Specification(Expression<Func<TEntity, bool>> criteria) => Criteria = criteria;

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) => 
            IncludeExpressions.Add(includeExpression);
    }
}

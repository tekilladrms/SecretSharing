using Microsoft.EntityFrameworkCore;
using SecretSharing.Domain.Primitives;
using SecretSharing.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Persistence.Specifications
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(
            IQueryable<TEntity> inputQueryable,
            Specification<TEntity> specification)
            where TEntity : Entity
        {
            IQueryable<TEntity> queryable = inputQueryable;

            if(specification.Criteria is not null)
            {
                queryable = queryable.Where(specification.Criteria);
            }

            queryable = specification.IncludeExpressions.Aggregate(
                queryable, (current, includeExpression) => 
                current.Include(includeExpression));

            return queryable;
        }
    }
}

using SecretSharing.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<IEnumerable<TEntity>> GetAllBySpecificationAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);
        public Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        
    }
}
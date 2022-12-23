using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Persistence.Repositories
{
    public class UserProfileRepository : IRepository<UserProfile>
    {
        private readonly ApplicationDbContext _context;
        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<UserProfile>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public Task<UserProfile> AddAsync(UserProfile entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public UserProfile Update(UserProfile entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserProfile entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

    }
}

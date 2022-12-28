using SecretSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Domain.Repositories
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        public Task<UserProfile> GetByIdWithDocumentsAsync(Guid id, CancellationToken cancellationToken);
    }
}

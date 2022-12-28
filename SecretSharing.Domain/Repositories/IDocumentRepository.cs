using SecretSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Domain.Repositories
{
    public interface IDocumentRepository : IRepository<Document>
    {
        public Task<Document> GetByIdWithUsersAsync(Guid id, CancellationToken cancellationToken);
        public Task<Document> GetByIdWithCreatorAsync(Guid id, CancellationToken cancellationToken);
    }
}

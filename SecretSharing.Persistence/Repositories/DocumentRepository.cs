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
    public class DocumentRepository : IRepository<Document>
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public Task<IEnumerable<Document>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Document> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Document> AddAsync(Document entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Document Update(Document entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Delete(Document entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        
    }
}

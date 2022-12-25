using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecretSharing.Persistence.Exceptions;

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

        public async Task<Document> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var document = await _context.Set<Document>().FirstOrDefaultAsync(doc => doc.Guid == id);

            if (document is null) throw new NotFoundPersistencseException($"Document with id = {id} was not found");

            return document;
        }

        public async Task<Document> AddAsync(Document entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<Document>().AddAsync(entity);
            return await GetByIdAsync(entity.Guid);
        }

        public Document Update(Document entity, CancellationToken cancellationToken = default)
        {
            _context.Set<Document>().Update(entity);

            return _context.Set<Document>().FirstOrDefault(doc => doc.Guid == entity.Guid);
        }

        public void Delete(Guid id, CancellationToken cancellationToken = default)
        {
            _context.Set<Document>().Remove(_context.Set<Document>().FirstOrDefault(doc => doc.Guid == id));
        }

        public void Delete(Document entity, CancellationToken cancellationToken = default)
        {
            _context.Set<Document>().Remove(entity);
        }

        Document IRepository<Document>.Update(Document entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

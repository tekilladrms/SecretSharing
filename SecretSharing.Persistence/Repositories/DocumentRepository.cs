using Microsoft.EntityFrameworkCore;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using SecretSharing.Persistence.Exceptions;
using SecretSharing.Persistence.Specifications;
using SecretSharing.Persistence.Specifications.DocumentSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace SecretSharing.Persistence.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        public DocumentRepository(ApplicationDbContext context) => _context = context;


        public async Task<IEnumerable<Document>> GetAllBySpecificationAsync(
            Specification<Document> specification,
            CancellationToken cancellationToken = default) =>
            await ApplySpecification(specification)
            .ToListAsync(cancellationToken);

        public async Task<Document> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var document = await _context.Set<Document>().FirstOrDefaultAsync(doc => doc.Guid == id);

            if (document is null) throw new NotFoundPersistencseException($"Document with id = {id} was not found");

            return document;
        }

        public async Task<Document> GetByIdWithUsersAsync(Guid id, 
            CancellationToken cancellationToken = default) =>
            await ApplySpecification(
                new DocumentByIdWithUsersSpecification(id))
            .FirstOrDefaultAsync(cancellationToken);

        public async Task<Document> GetByIdWithCreatorAsync(
            Guid id, CancellationToken cancellationToken = default) =>
            await ApplySpecification(
                new DocumentByIdWithCreatorSpecification(id))
            .FirstOrDefaultAsync(cancellationToken);

        public async Task<Guid> AddAsync(Document entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<Document>().AddAsync(entity);
            return entity.Guid;
        }

        public async Task<Document> Update(Document entity, CancellationToken cancellationToken = default)
        {
            _context.Set<Document>().Update(entity);

            return await GetByIdAsync(entity.Guid);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            _context.Set<Document>().Remove(await GetByIdAsync(id));
        }

        private IQueryable<Document> ApplySpecification(Specification<Document> specification)
        {
            return SpecificationEvaluator.GetQuery(
                _context.Set<Document>(),
                specification);
        }

        
    }
}

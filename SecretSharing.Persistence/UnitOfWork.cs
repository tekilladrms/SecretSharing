using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using SecretSharing.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace SecretSharing.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly ApplicationDbContext _context;

        private IUserProfileRepository _userProfiles;
        private IDocumentRepository _documents;


        IUserProfileRepository IUnitOfWork.UserProfiles => _userProfiles;

        IDocumentRepository IUnitOfWork.Documents => _documents;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _userProfiles = new UserProfileRepository(_context);
            _documents = new DocumentRepository(_context);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

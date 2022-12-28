using SecretSharing.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SecretSharing.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserProfileRepository UserProfiles { get; }
        public IDocumentRepository Documents { get; }

        Task<int> SaveChangesAsync();
    }
}
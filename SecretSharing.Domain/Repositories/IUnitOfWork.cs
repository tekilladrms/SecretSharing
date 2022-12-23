using SecretSharing.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SecretSharing.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<UserProfile> UserProfiles { get; }
        public IRepository<Document> Documents { get; }
        Task<int> SaveChangesAsync();
    }
}
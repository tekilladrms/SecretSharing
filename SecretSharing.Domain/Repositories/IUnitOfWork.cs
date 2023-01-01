using Microsoft.AspNetCore.Identity;
using SecretSharing.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SecretSharing.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IDocumentRepository Documents { get; }
        public UserManager<ApplicationUser> Users { get; }
        
        Task<int> SaveChangesAsync();
    }
}
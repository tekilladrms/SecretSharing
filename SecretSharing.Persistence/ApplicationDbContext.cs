using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecretSharing.Domain.Entities;
using SecretSharing.Persistence.Configurations;

namespace SecretSharing.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        // for tests
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create(DbContextOptions<ApplicationDbContext> dbContextOptions)
        {
            return new ApplicationDbContext(dbContextOptions);
        }
    }
}

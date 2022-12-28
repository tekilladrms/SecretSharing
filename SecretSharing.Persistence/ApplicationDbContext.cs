using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecretSharing.Application.Users;
using SecretSharing.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSharing.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // for tests
        public ApplicationDbContext() { }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create(DbContextOptions<ApplicationDbContext> dbContextOptions)
        {
            return new ApplicationDbContext(dbContextOptions);
        }
    }
}

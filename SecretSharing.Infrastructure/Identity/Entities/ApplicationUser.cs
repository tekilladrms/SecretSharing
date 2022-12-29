using Microsoft.AspNetCore.Identity;
using SecretSharing.Domain.Entities;
using System;

namespace SecretSharing.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}

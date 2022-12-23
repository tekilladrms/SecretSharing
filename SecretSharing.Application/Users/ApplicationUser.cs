using Microsoft.AspNetCore.Identity;
using SecretSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.Users
{
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}

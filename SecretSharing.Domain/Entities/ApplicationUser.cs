using Microsoft.AspNetCore.Identity;
using SecretSharing.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SecretSharing.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string GetNameFromEmail(string email)
        {
            return email.Substring(0, email.IndexOf('@'));
        }
    }
}

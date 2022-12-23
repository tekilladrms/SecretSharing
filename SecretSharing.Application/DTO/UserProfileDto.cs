using Microsoft.AspNetCore.Identity;
using SecretSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.DTO
{
    public class UserProfileDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Document> Documents { get; set; }
    }
}

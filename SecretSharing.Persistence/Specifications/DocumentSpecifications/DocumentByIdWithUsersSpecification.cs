using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Persistence.Specifications.DocumentSpecifications
{
    internal class DocumentByIdWithUsersSpecification : Specification<Document>
    {
        public DocumentByIdWithUsersSpecification(Guid DocumentId)
            : base(document => document.Guid == DocumentId)
        {
            AddInclude(document => document.Users);
        }
    }
}

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
    internal class DocumentByIdWithCreatorSpecification : Specification<Document>
    {
        public DocumentByIdWithCreatorSpecification(Guid id) 
            : base(document => document.Guid == id)
        {
            AddInclude(document => document.Creator);
        }
    }
}

using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Persistence.Specifications.UserProfileSpecifications
{
    internal class UserByIdWithDocumentsSpecification : Specification<UserProfile>
    {
        public UserByIdWithDocumentsSpecification(Guid UserProfileId)
            : base(userProfile => userProfile.Guid == UserProfileId)
        {
            AddInclude(userProfile => userProfile.Documents);
        }
    }
}

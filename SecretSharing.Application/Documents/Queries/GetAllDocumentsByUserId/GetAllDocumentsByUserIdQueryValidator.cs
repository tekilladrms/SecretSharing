using FluentValidation;
using SecretSharing.Domain.DomainRulesValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Queries.GetAllDocumentsByUserId
{
    public class GetAllDocumentsByUserIdQueryValidator : AbstractValidator<GetAllDocumentsByUserIdQuery>
    {
        public GetAllDocumentsByUserIdQueryValidator()
        {
            RuleFor(getAllDocumentsByUserIdQuery => getAllDocumentsByUserIdQuery.UserId)
                .NotNull()
                .Must(RulesForGuid.IsGuid).WithMessage("UserId should be guid");
                
        }
    }
}

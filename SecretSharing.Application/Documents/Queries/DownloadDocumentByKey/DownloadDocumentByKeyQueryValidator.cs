using FluentValidation;
using SecretSharing.Domain.DomainRulesValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Queries.GetDocumentByKey
{
    public class DownloadDocumentByKeyQueryValidator : AbstractValidator<DownloadDocumentByKeyQuery>
    {
        public DownloadDocumentByKeyQueryValidator()
        {
            RuleFor(downloadDocumentByKeyQuery => downloadDocumentByKeyQuery.UserId)
                .NotNull()
                .Must(RulesForGuid.IsGuid).WithMessage("UserId should be guid");

            RuleFor(downloadDocumentByKeyQuery => downloadDocumentByKeyQuery.FileName)
                .NotEmpty()
                .NotNull();

            RuleFor(downloadDocumentByKeyQuery => downloadDocumentByKeyQuery.Path)
                .Must(RulesForUrl.IsUrl).WithMessage("Path should be url");
        }
    }
}

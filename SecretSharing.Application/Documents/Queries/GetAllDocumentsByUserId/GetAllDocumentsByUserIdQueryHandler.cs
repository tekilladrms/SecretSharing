using MediatR;
using Microsoft.AspNetCore.Identity;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Exceptions;
using SecretSharing.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Queries.GetAllDocumentsByUserId
{
    public class GetAllDocumentsByUserIdQueryHandler : IRequestHandler<GetAllDocumentsByUserIdQuery, IReadOnlyCollection<string>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDocumentStorage _documentStorage;

        public GetAllDocumentsByUserIdQueryHandler(UserManager<ApplicationUser> userManager, IDocumentStorage documentStorage)
        {
            _userManager = userManager;
            _documentStorage = documentStorage;
        }

        public async Task<IReadOnlyCollection<string>> Handle(GetAllDocumentsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user is null) throw new NotFoundDomainException($"User with id = {request.UserId} was not found");

            var result = await _documentStorage.GetAllDocuments(user.Id, cancellationToken);

            return result;
        }
    }
}

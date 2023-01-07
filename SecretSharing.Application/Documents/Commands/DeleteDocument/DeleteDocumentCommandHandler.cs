using MediatR;
using Microsoft.AspNetCore.Identity;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Exceptions;
using SecretSharing.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Commands.DeleteDocument
{
    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand, Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDocumentStorage _documentStorage;

        public DeleteDocumentCommandHandler(UserManager<ApplicationUser> userManager, IDocumentStorage documentStorage)
        {
            _userManager = userManager;
            _documentStorage = documentStorage;
        }

        public async Task<Unit> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user is null) throw new NotFoundDomainException($"User with id = {request.UserId} was not found");

            await _documentStorage.DeleteDocumentAsync(user.Id, request.FileName, cancellationToken);

            return Unit.Value;
        }
    }
}

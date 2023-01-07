using MediatR;
using Microsoft.AspNetCore.Identity;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Exceptions;
using SecretSharing.Domain.Repositories;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Commands.CreateDocument
{
    internal class CreateDocumentFromFileCommandHandler : IRequestHandler<CreateDocumentFromFileCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDocumentStorage _documentStorage;

        public CreateDocumentFromFileCommandHandler(UserManager<ApplicationUser> userManager, IDocumentStorage documentStorage)
        {
            _userManager = userManager;
            _documentStorage = documentStorage;
        }

        public async Task<string> Handle(CreateDocumentFromFileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user is null) throw new NotFoundDomainException($"User with id = {request.UserId} was not found");

            var result = await _documentStorage.UploadDocumentFromFileAsync(request.File, user.Id, cancellationToken);


            return result;
        }
    }
}

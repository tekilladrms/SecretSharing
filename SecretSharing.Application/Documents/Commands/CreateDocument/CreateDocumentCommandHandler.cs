using AutoMapper;
using MediatR;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Commands.CreateDocument
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, DocumentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DocumentDto> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserProfiles.GetByIdAsync(request.UserProfileId);
            var document = Document.Create(request.DocumentDto.Name, user);

            user.AddDocumentToDocuments(document);
            document.AddUserToUsers(user);

            await _unitOfWork.Documents.AddAsync(document);
            _unitOfWork.UserProfiles.Update(user);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<DocumentDto>(document);
        }
    }
}

using Amazon.S3.Model;
using Amazon.S3;
using AutoMapper;
using MediatR;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Primitives;
using SecretSharing.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using SecretSharing.Domain.ValueObjects;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace SecretSharing.Application.Documents.Commands.CreateDocument
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, DocumentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAmazonS3 _amazonS3;
        private readonly IConfiguration _configuration;

        public CreateDocumentCommandHandler(IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAmazonS3 amazonS3, 
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _amazonS3 = amazonS3;
            _configuration = configuration;
        }

        public async Task<DocumentDto> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserProfiles.GetByIdWithDocumentsAsync(request.UserProfileId, cancellationToken);
            var document = Document.Create(
                request.DocumentDto.Name, 
                user, 
                S3Info.Create(
                    _configuration["BucketName"],
                    $"{user.FirstName} {user.LastName}",
                    request.DocumentDto.File.FileName,
                    request.DocumentDto.File.ContentDisposition)
                );

            await _amazonS3.EnsureBucketExistsAsync(document.S3Info.BucketName);

            var s3request = new PutObjectRequest()
            {
                BucketName = document.S3Info.BucketName,
                Key = $"{document.S3Info.FolderName}/{document.S3Info.FileName}",
                FilePath = document.S3Info.LocalPath
            };

            var response = await _amazonS3.PutObjectAsync(s3request);

            if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                
            }

            user.AddDocumentToDocuments(document);
            document.AddUserToUsers(user);

            await _unitOfWork.Documents.AddAsync(document);
            _unitOfWork.UserProfiles.Update(user);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<DocumentDto>(document);
        }
    }
}

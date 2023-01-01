using Amazon.S3;
using Amazon.S3.Model;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Exceptions;
using SecretSharing.Domain.Repositories;
using SecretSharing.Domain.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

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
            var user = await _unitOfWork.Users.FindByIdAsync(request.UserId.ToString());

            if(user is null)
            {
                throw new NotFoundDomainException($"User with Id = {request.UserId} was not found");
            }

            var document = Document.Create(
                request.DocumentDto.Name, 
                user, 
                S3Info.Create(
                    _configuration["BucketName"],
                    $"{user.UserName}",
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
                throw new DocumentWasNotUploadedDomainException(
                    $"Document {document.S3Info.LocalPath} was not uploaded");

            }

            user.AddDocumentToDocuments(document);
            document.AddUserToUsers(user);

            await _unitOfWork.Documents.AddAsync(document);
            await _unitOfWork.Users.UpdateAsync(user);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<DocumentDto>(document);
        }
    }
}

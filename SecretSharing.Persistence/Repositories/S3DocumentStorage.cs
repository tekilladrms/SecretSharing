using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SecretSharing.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Persistence.Repositories
{
    public class S3DocumentStorage : IDocumentStorage
    {
        private readonly IAmazonS3 _amazonS3;
        private readonly IConfiguration _configuration;
        private readonly string _bucketName;

        public S3DocumentStorage(IAmazonS3 amazonS3, IConfiguration configuration)
        {
            _amazonS3 = amazonS3;
            _configuration = configuration;
            _bucketName = _configuration["AWS:BucketName"];
            _amazonS3.EnsureBucketExistsAsync(_bucketName);
        }


        public async Task<IReadOnlyCollection<string>> GetAllDocuments(string userId, CancellationToken cancellationToken = default)
        {
            var request = new ListObjectsV2Request()
            {
                BucketName = _bucketName,
                Prefix = $"{userId}/"
            };

            var response = await _amazonS3.ListObjectsV2Async(request, cancellationToken);

            List<string> result = new();

            foreach (var el in response.S3Objects)
            {
                result.Add(el.Key);
            }
            return result;
        }

        public async Task<string> UploadDocumentFromFileAsync(IFormFile file, string userId, CancellationToken cancellationToken = default)
        {
            var result = await UploadDocument(
                new TransferUtilityUploadRequest()
                {
                    CannedACL = S3CannedACL.PublicRead,
                    BucketName = _bucketName,
                    Key = $"{userId}/{file.FileName}",
                    InputStream = file.OpenReadStream(),
                    ContentType = file.ContentType
                });
            return result;
        }

        public async Task<string> UploadDocumentFromTextAsync(string text, string title, string userId, CancellationToken cancellationToken = default)
        {
            byte[] buffer = Encoding.Default.GetBytes(text);
            MemoryStream memoryStream = new MemoryStream(buffer);

            var result = await UploadDocument(
                new TransferUtilityUploadRequest()
                {
                    CannedACL = S3CannedACL.PublicRead,
                    BucketName = _bucketName,
                    Key = $"{userId}/{title}",
                    InputStream = memoryStream,
                    ContentType = "text/plain",
                    AutoCloseStream = true
                });

            return result;
        }

        private async Task<string> UploadDocument(TransferUtilityUploadRequest request)
        {
            var transferUtility = new TransferUtility(_amazonS3);
            await transferUtility.UploadAsync(request);

            return GetUrl(request);
        }

        // build the url
        private string GetUrl(TransferUtilityUploadRequest request)
        {
            return $"https://{_bucketName}.s3.{_configuration["AWS:Region"]}.amazonaws.com/{request.Key}";
        }


        public async Task<(MemoryStream, string)> DownloadDocumentAsync(string userId, string fileName, string path, CancellationToken cancellationToken = default)
        {
            var response = await _amazonS3.GetObjectAsync(_bucketName, $"{userId}/{fileName}", cancellationToken);

            using Stream responseStream = response.ResponseStream;
            var stream = new MemoryStream();
            await responseStream.CopyToAsync(stream);
            stream.Position = 0;

            //await response.WriteResponseStreamToFileAsync(path, false, cancellationToken);

            return (stream, response.Headers.ContentType);
        }

        public async Task DeleteDocumentAsync(string userId, string fileName, CancellationToken cancellationToken = default)
        {
            var request = new DeleteObjectRequest()
            {
                BucketName = _bucketName,
                Key = $"{userId}/{fileName}"
            };

            await _amazonS3.DeleteObjectAsync(request, cancellationToken);
        }

        public Task DeleteAllDocumentsAsync(string userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }


    }
}

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Domain.Repositories
{
    public interface IDocumentStorage
    {
        public Task<IReadOnlyCollection<string>> GetAllDocuments(string userId, CancellationToken cancellationToken);

        public Task<string> UploadDocumentFromFileAsync(IFormFile file, string userId, CancellationToken cancellationToken);

        public Task<string> UploadDocumentFromTextAsync(string text, string title, string userId, CancellationToken cancellationToken);

        public Task<(MemoryStream, string)> DownloadDocumentAsync(string userId, string fileName, string path, CancellationToken cancellationToken);

        public Task DeleteDocumentAsync(string userId, string fileName, CancellationToken cancellationToken);

        public Task DeleteAllDocumentsAsync(string userId, CancellationToken cancellationToken);

    }
}

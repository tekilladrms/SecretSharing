using MediatR;
using SecretSharing.Domain.Repositories;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Queries.GetDocumentByKey
{
    internal class DownloadDocumentByKeyQueryHandler : IRequestHandler<DownloadDocumentByKeyQuery, (MemoryStream, string)>
    {
        private readonly IDocumentStorage _documentStorage;

        public DownloadDocumentByKeyQueryHandler(IDocumentStorage documentStorage)
        {
            _documentStorage = documentStorage;
        }

        public async Task<(MemoryStream, string)> Handle(DownloadDocumentByKeyQuery request, CancellationToken cancellationToken)
        {
            var (result, contentType) = await _documentStorage.DownloadDocumentAsync(
                request.UserId, 
                request.FileName, 
                request.Path, 
                cancellationToken);

            return (result, contentType);

        }
    }
}

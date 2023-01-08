using MediatR;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace SecretSharing.Application.Documents.Queries.GetDocumentByKey
{
    public sealed record DownloadDocumentByKeyQuery([Required] string UserId, string FileName, string Path) : IRequest<(MemoryStream, string)>;
}

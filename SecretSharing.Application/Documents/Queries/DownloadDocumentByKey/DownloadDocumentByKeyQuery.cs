using MediatR;
using SecretSharing.Application.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Queries.GetDocumentByKey
{
    public sealed record DownloadDocumentByKeyQuery(string UserId, string FileName, string Path) : IRequest<(MemoryStream, string)>;
}

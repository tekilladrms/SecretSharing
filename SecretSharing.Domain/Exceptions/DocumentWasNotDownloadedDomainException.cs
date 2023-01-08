using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Domain.Exceptions
{
    public class DocumentWasNotDownloadedDomainException : DomainException
    {
        public DocumentWasNotDownloadedDomainException(string message) : base(message)
        {

        }
    }
}

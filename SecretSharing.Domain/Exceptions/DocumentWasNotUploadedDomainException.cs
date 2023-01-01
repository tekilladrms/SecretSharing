using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Domain.Exceptions
{
    public class DocumentWasNotUploadedDomainException : DomainException
    {
        public DocumentWasNotUploadedDomainException(string message) : base(message)
        {

        }
    }
}

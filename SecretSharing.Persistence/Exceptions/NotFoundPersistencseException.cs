using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Persistence.Exceptions
{
    public class NotFoundPersistencseException : PersistenceException
    {
        public NotFoundPersistencseException(string message) : base(message)
        {
        }
    }
}

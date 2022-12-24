using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Persistence.Exceptions
{
    public abstract class PersistenceException : Exception
    {
        protected PersistenceException(string message) : base(message) { }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Persistence.Exceptions
{
    public class NotFoundPersistenceException : PersistenceException
    {
        public NotFoundPersistenceException(string message) : base(message)
        {
        }
    }
}

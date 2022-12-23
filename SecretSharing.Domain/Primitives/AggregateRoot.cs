using System;

namespace SecretSharing.Domain.Primitives
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot() : base()
        {
        }
    }
}
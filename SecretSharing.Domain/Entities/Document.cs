using SecretSharing.Domain.Primitives;
using SecretSharing.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SecretSharing.Domain.Entities
{
    public class Document : Entity
    {
        public DocumentName Name { get; private set; }

        public Guid CreatorId { get; private set; }

        public virtual IReadOnlyCollection<UserProfile> Users { get; private set; }


        // For EF
        private Document() : base() { }

        private Document(DocumentName name, Guid creatorId)
        {
            Name = name;
            CreatorId = creatorId;
            Users = new List<UserProfile>();
        }

        public static Document Create(string name, Guid creatorId)
        {
            return new Document(DocumentName.Create(name), creatorId);
        }
    }
}

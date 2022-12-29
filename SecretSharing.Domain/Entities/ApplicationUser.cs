using Microsoft.AspNetCore.Identity;
using SecretSharing.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SecretSharing.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        private List<Document> _documents = new();
        public IReadOnlyCollection<Document> Documents => _documents;

        public void AddDocumentToDocumentList(Document document)
        {
            _documents.Add(document);
            
        }
    }
}

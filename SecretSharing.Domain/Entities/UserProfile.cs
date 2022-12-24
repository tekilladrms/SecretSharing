using SecretSharing.Domain.Exceptions;
using SecretSharing.Domain.Primitives;
using SecretSharing.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace SecretSharing.Domain.Entities
{
    public class UserProfile : AggregateRoot
    {
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }

        private List<Document> _documents = new();

        public virtual IReadOnlyCollection<Document> Documents => _documents;

        // For EF
        private UserProfile() { }

        private UserProfile(Name firstName, Name lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }  
        
        public static UserProfile Create()
        {
            return new UserProfile(
                Name.Create(string.Empty),
                Name.Create(string.Empty));
        }
        public static UserProfile Create(string firstName, string lastName)
        {
            return new UserProfile(
                Name.Create(firstName),
                Name.Create(lastName));
        }

        public void ChangeFirstName(string firstName)
        {
            FirstName = Name.Create(firstName);
        }

        public void ChangeLastName(string lastName)
        {
            LastName = Name.Create(lastName);
        }

        public void AddDocumentToDocumentList(Document document)
        {
            if(document is null) throw new ArgumentNullDomainException(nameof(document));

            _documents.Add(document);
        }

        public void RemoveDocumentFromDocumentList(Document document)
        {
            if(document is null) throw new ArgumentNullDomainException(nameof(document));

            _documents.Remove(document);
        }

        

    }
}

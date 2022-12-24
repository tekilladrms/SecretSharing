using SecretSharing.Domain.Primitives;
using SecretSharing.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SecretSharing.Domain.Entities
{
    public class Document : Entity
    {
        public DocumentName Name { get; private set; }

        public UserProfile Creator { get; private set; }

        private List<UserProfile> _users;
        public virtual IReadOnlyCollection<UserProfile> Users => _users ??= new List<UserProfile>();


        // For EF
        private Document() : base() { }

        private Document(DocumentName name, UserProfile creator)
        {
            Name = name;
            Creator = creator;
            
            _users.Add(Creator);
        }

        public static Document Create(string name, UserProfile creator)
        {
            return new Document(DocumentName.Create(name), creator);
        }

        public void AddUserToUsers(UserProfile user)
        {
            _users.Add(user);

        }
        public void DeleteUserFromUsers(UserProfile user)
        {
            _users.Remove(user);
        }
    }
}

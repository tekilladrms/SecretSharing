using SecretSharing.Domain.Primitives;
using SecretSharing.Domain.ValueObjects;
using System.Collections.Generic;

namespace SecretSharing.Domain.Entities
{
    public class Document : Entity
    {
        public DocumentName Name { get; private set; }

        public UserProfile Creator { get; private set; }

        public S3Info S3Info { get; private set; }

        private List<UserProfile> _users = new();
        public virtual IReadOnlyCollection<UserProfile> Users => _users;


        // For EF
        private Document() : base() { }

        private Document(DocumentName name, UserProfile creator, S3Info s3Info)
        {
            Name = name;
            Creator = creator;
            S3Info = s3Info;
            AddUserToUsers(Creator);
        }

        public static Document Create(string name, UserProfile creator, S3Info s3Info)
        {
            return new Document(DocumentName.Create(name), creator, s3Info);
        }

        public void ChangeName(string newName)
        {
            Name = DocumentName.Create(newName);

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

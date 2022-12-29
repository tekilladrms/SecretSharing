using Moq;
using Moq.EntityFrameworkCore;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.ValueObjects;
using SecretSharing.Persistence;
using System;
using System.Collections.Generic;

namespace Persistence.Tests.Mocks
{
    public static class MockDbContext
    {
        public static (Mock<ApplicationDbContext>, Guid) GetMockWithUserProfileId()
        {
            var mock = new Mock<ApplicationDbContext>();
            var profiles = new List<UserProfile>()
            {
                UserProfile.Create(
                    "John",
                    "Doe"
                    ),
                UserProfile.Create(
                    "Jane",
                    "Doe"
                    ),
                UserProfile.Create(
                    "Harold",
                    "Doe"
                    ),
            };
            var documents = new List<Document>()
            {
                Document.Create("first",
                profiles[0],
                S3Info.Create("SecretSharing",
                $"{profiles[0].FirstName.Value}{profiles[0].LastName.Value}",
                "hjkhjk",
                "asdasdasd")),
                Document.Create("second",
                profiles[0],
                S3Info.Create("SecretSharing",
                $"{profiles[0].FirstName.Value}{profiles[0].LastName.Value}",
                "hjkhjk",
                "asdasdasd")),
                Document.Create("third",
                profiles[1],
                S3Info.Create("SecretSharing",
                $"{profiles[1].FirstName.Value}{profiles[1].LastName.Value}",
                "hjkhjk",
                "asdasdasd"))
            };

            // setups

            mock.Setup(m => m.Set<UserProfile>()).ReturnsDbSet(profiles);
            mock.Setup(m => m.Set<Document>()).ReturnsDbSet(documents);

            profiles[0].AddDocumentToDocuments(documents[0]);
            profiles[0].AddDocumentToDocuments(documents[1]);
            profiles[1].AddDocumentToDocuments(documents[2]);

            documents[0].AddUserToUsers(profiles[0]);
            documents[1].AddUserToUsers(profiles[0]);
            documents[2].AddUserToUsers(profiles[1]);

            return (mock, profiles[0].Guid);
        }

        public static (Mock<ApplicationDbContext>, Guid) GetMockWithDocumentId()
        {
            var mock = new Mock<ApplicationDbContext>();
            var profiles = new List<UserProfile>()
            {
                UserProfile.Create(
                    "John",
                    "Doe"
                    ),
                UserProfile.Create(
                    "Jane",
                    "Doe"
                    ),
                UserProfile.Create(
                    "Harold",
                    "Doe"
                    ),
            };
            var documents = new List<Document>()
            {
                Document.Create("first",
                profiles[0],
                S3Info.Create("SecretSharing",
                $"{profiles[0].FirstName.Value}{profiles[0].LastName.Value}",
                "hjkhjk",
                "asdasdasd")),
                Document.Create("second",
                profiles[0],
                S3Info.Create("SecretSharing",
                $"{profiles[0].FirstName.Value}{profiles[0].LastName.Value}",
                "hjkhjk",
                "asdasdasd")),
                Document.Create("third",
                profiles[1],
                S3Info.Create("SecretSharing",
                $"{profiles[1].FirstName.Value}{profiles[1].LastName.Value}",
                "hjkhjk",
                "asdasdasd"))
            };

            // setups

            mock.Setup(m => m.Set<UserProfile>()).ReturnsDbSet(profiles);
            mock.Setup(m => m.Set<Document>()).ReturnsDbSet(documents);

            profiles[0].AddDocumentToDocuments(documents[0]);
            profiles[0].AddDocumentToDocuments(documents[1]);
            profiles[1].AddDocumentToDocuments(documents[2]);

            documents[0].AddUserToUsers(profiles[0]);
            documents[1].AddUserToUsers(profiles[0]);
            documents[2].AddUserToUsers(profiles[1]);

            return (mock, documents[0].Guid);
        }

        public static Mock<ApplicationDbContext> GetMock()
        {
            var mock = new Mock<ApplicationDbContext>();
            var profiles = new List<ApplicationUser>()
            {
                new ApplicationUser.Create(
                    "John",
                    "Doe"
                    ),
                UserProfile.Create(
                    "Jane",
                    "Doe"
                    ),
                UserProfile.Create(
                    "Harold",
                    "Doe"
                    ),
            };
            var documents = new List<Document>()
            {
                Document.Create("first",
                profiles[0],
                S3Info.Create("SecretSharing",
                $"{profiles[0].FirstName.Value}{profiles[0].LastName.Value}",
                "hjkhjk",
                "asdasdasd")),
                Document.Create("second",
                profiles[0],
                S3Info.Create("SecretSharing",
                $"{profiles[0].FirstName.Value}{profiles[0].LastName.Value}",
                "hjkhjk",
                "asdasdasd")),
                Document.Create("third",
                profiles[1],
                S3Info.Create("SecretSharing",
                $"{profiles[1].FirstName.Value}{profiles[1].LastName.Value}",
                "hjkhjk",
                "asdasdasd"))
            };

            profiles[0].AddDocumentToDocuments(documents[0]);
            profiles[0].AddDocumentToDocuments(documents[1]);
            profiles[1].AddDocumentToDocuments(documents[2]);

            documents[0].AddUserToUsers(profiles[0]);
            documents[1].AddUserToUsers(profiles[0]);
            documents[2].AddUserToUsers(profiles[1]);

            // setups


            mock.Setup(m => m.Set<ApplicationUser>()).ReturnsDbSet(profiles);
            mock.Setup(m => m.Set<Document>()).ReturnsDbSet(documents);

            return mock;
        }
    }
}

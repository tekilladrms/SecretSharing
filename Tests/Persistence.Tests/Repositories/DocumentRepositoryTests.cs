//using Persistence.Tests.Mocks;
//using SecretSharing.Domain.Entities;
//using SecretSharing.Domain.ValueObjects;
//using SecretSharing.Persistence.Exceptions;
//using SecretSharing.Persistence.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Persistence.Tests.Repositories
//{
//    public class DocumentRepositoryTests
//    {
//        private readonly Document document;
//        public DocumentRepositoryTests()
//        {
//            profile = UserProfile.Create();
//            document = Document.Create("Document",
//                profile,
//                S3Info.Create("Bucket", "FolderNAme", "FileName", "LocalPath"));

//        }

//        [Fact]
//        public async Task GetByIdAsync_Should_ReturnInstance_WhenRecordIsExistInDatabase()
//        {
//            // arrange
//            var (mockDbContext, id) = MockDbContext.GetMockWithDocumentId();
//            var repository = new DocumentRepository(mockDbContext.Object);

//            // act
//            var documentResult = await repository.GetByIdAsync(id);

//            // assert
//            Assert.NotNull(documentResult);
//            Assert.IsType<Document>(documentResult);
//        }

//        [Fact]
//        public async Task GetByIdAsync_Should_ThrowException_WhenRecordWasNotFound()
//        {
//            // arrange
//            var mockDbContext = MockDbContext.GetMock();
//            var repository = new DocumentRepository(mockDbContext.Object);
//            Guid id = Guid.NewGuid();

//            // act

//            // assert
//            await Assert.ThrowsAsync<NotFoundPersistenceException>(async () => await repository.GetByIdAsync(id));
//        }

//        [Fact]
//        public async Task AddAsync_Should_AddRecordToDatabase_AndReturnGuid()
//        {
//            // arrange
//            var mockDbContext = MockDbContext.GetMock();
//            var repository = new DocumentRepository(mockDbContext.Object);

//            //act
//            var result = await repository.AddAsync(document);


//            //assert
//            Assert.NotEqual(Guid.Empty, result);
//            Assert.IsType<Guid>(result);
//        }

//        [Fact]
//        public async Task Update_Should_UpdateRecord_AndReturnUpdatedInstance()
//        {
//            // arrange
//            var (mockDbContext, id) = MockDbContext.GetMockWithDocumentId();
//            var repository = new DocumentRepository(mockDbContext.Object);

//            // act
//            var document = await repository.GetByIdAsync(id);
//            document.ChangeName("Alex");

//            var userProfileResult = repository.Update(document);

//            // assert
//            Assert.NotNull(userProfileResult);
//            Assert.Equal("Alex", userProfileResult.Result.Name.Value);
//        }

//        [Fact]
//        public async Task GetByIdWithUsersAsync_Should_ReturnDocumentInstanceWithUserProfiles()
//        {
//            // arrange
//            var (mockDbContext, id) = MockDbContext.GetMockWithDocumentId();
//            var repository = new DocumentRepository(mockDbContext.Object);

//            // act
//            var documentResult = await repository.GetByIdWithUsersAsync(id);

//            // assert
//            Assert.NotNull(documentResult);
//            Assert.NotNull(documentResult.Users);
//            Assert.NotEmpty(documentResult.Users);
//        }

//        [Fact]
//        public async Task GetByIdWithCreatorAsync_Should_ReturnDocumentInstanceWithCreator()
//        {
//            // arrange
//            var (mockDbContext, id) = MockDbContext.GetMockWithDocumentId();
//            var repository = new DocumentRepository(mockDbContext.Object);

//            // act
//            var documentResult = await repository.GetByIdWithCreatorAsync(id);

//            // assert
//            Assert.NotNull(documentResult.Creator);

//        }
//    }
//}

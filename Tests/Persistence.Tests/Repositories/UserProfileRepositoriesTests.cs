using Persistence.Tests.Mocks;
using SecretSharing.Domain.Entities;
using SecretSharing.Persistence.Exceptions;
using SecretSharing.Persistence.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Persistence.Tests.Repositories
{
    public class UserProfileRepositoriesTests
    {
        private readonly UserProfile userProfile;
        public UserProfileRepositoriesTests()
        {
            userProfile = UserProfile.Create();
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnsInstance_WhenRecordWithIdIsExistInDatabase()
        {
            // arrange
            var (mockDbContext, id) = MockDbContext.GetMockWithUserProfileId();
            var repository = new UserProfileRepository(mockDbContext.Object);

            // act

            var userProfileResult = await repository.GetByIdAsync(id);

            // Assert

            Assert.NotNull(userProfileResult);
            Assert.IsType<UserProfile>(userProfileResult);
        }

        [Fact]
        public async Task GetByIdAsync_Should_ThrowException_WhenRecordWasNotFound()
        {
            // arrange
            var mockDbContext = MockDbContext.GetMock();
            var repository = new UserProfileRepository(mockDbContext.Object);
            Guid id = Guid.NewGuid();

            // act

            // assert
            await Assert.ThrowsAsync<NotFoundPersistencseException>(async() => await repository.GetByIdAsync(id));
        }

        [Fact]
        public async Task AddAsync_Should_AddRecordToDatabase_AndReturnGuid()
        {
            // arrange
            var mockDbContext = MockDbContext.GetMock();
            var repository = new UserProfileRepository(mockDbContext.Object);

            //act
            var result = await repository.AddAsync(userProfile);


            //assert
            Assert.NotEqual(Guid.Empty, result);
            Assert.IsType<Guid>(result);
        }

        [Fact]
        public async Task Update_Should_UpdateRecord_AndReturnUpdatedInstance()
        {
            // arrange
            var (mockDbContext, id) = MockDbContext.GetMockWithUserProfileId();
            var repository = new UserProfileRepository(mockDbContext.Object);

            // act
            var userProfile = await repository.GetByIdAsync(id);
            userProfile.ChangeFirstName("Alex");

            var userProfileResult = repository.Update(userProfile);

            // assert
            Assert.NotNull(userProfileResult);
            Assert.Equal("Alex", userProfileResult.Result.FirstName.Value);
        }

        
    }
}

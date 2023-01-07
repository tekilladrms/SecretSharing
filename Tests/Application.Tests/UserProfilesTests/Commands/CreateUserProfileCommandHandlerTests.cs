//using AutoMapper;
//using MediatR;
//using Moq;
//using SecretSharing.Application;
//using SecretSharing.Persistence;
//using Xunit;

//namespace Application.Tests.UserProfilesTests.Commands
//{
//    public class CreateUserProfileCommandHandlerTests
//    {
//        private readonly Mock<ApplicationDbContext> _appDbContextMock;
//        private readonly IMapper _mapper;
//        private readonly IUnitOfWork _unitOfWork;

//        public CreateUserProfileCommandHandlerTests(IMapper mapper, IUnitOfWork unitOfWork)
//        {
//            var mapProfile = new MapProfile();
//            var config = new MapperConfiguration(cfg => cfg.AddProfile(mapProfile));
//            _mapper = new Mapper(config);
//            _unitOfWork = unitOfWork;

//            _appDbContextMock = new();
//            //_appDbContextMock.Setup(ctx => ctx.Set<UserProfile>().ReturnsDbSet)
//        }

//        [Fact]
//        public void Handle_Should_ReturnDTO_WhenAllParametersAreCorrect()
//        {
//            // Arrange
//            var mediator = new Mock<IMediator>();
//            var unitOfWork = new Mock<IUnitOfWork>();
//            var command = new CreateUserProfileCommand();
//            var handler = new CreateUserProfileCommandHandler(unitOfWork.Object, _mapper);


//            // Act

//            var result = handler.Handle(command);

//            // Assert

//            Assert.NotNull(result);
//        }
//    }
//}

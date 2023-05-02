using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using Castle.Core.Logging;
using Moq;
using TimeAndAttendanceSystem.Repositories.Mappers;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Repositories.Repos.Interfaces;
using TimeAndAttendanceSystem.Repositories.Repositories.Interfaces;
using TimeAndAttendanceSystem.Repositories.Repositories.Repos;
using TimeAndAttendanceSystem.Services.Services;

namespace TimeAndAttendanceSystem.Repositories.Tests.UserRepositoryServiceTests
{
    public class BaseTest
    {
        public MapperConfiguration config = new MapperConfiguration(x => x.AddProfile(new AutoMapperProfile()));

        public IMapper GetMapper()
        {
            return config.CreateMapper();
        }
    }

    public class UnitTest1 : BaseTest
    {
        private readonly Fixture _fixture = new Fixture();
        public UnitTest1()
        {
            _fixture.Customizations.Add(new UserSpecimenBuilder());
        }
        [Fact]
        public async Task Test1()
        {
            // Arrange
            var user = _fixture.Create<User>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var userDetailsRepositoryMock = new Mock<IUserDetailsRepository>();
            var userAddressRepositoryMock = new Mock<IUserAddressRepository>();
            var userPhotosRepositoryMock = new Mock<IUserPhotosRepository>();
           
            var sut = new UserService(
                userRepositoryMock.Object,
                userDetailsRepositoryMock.Object,
                userAddressRepositoryMock.Object,
                userPhotosRepositoryMock.Object,
                base.GetMapper());

            userRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(user);
            userRepositoryMock.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(user);

            //Act
            var testReponse1 = await sut.GetUserByID(It.IsAny<Guid>());
            var testReponse2 = await sut.GetUserByUserName(It.IsAny<string>());

            //Assert
            Assert.NotNull(testReponse1);
            Assert.NotNull(testReponse2);
            Assert.Equal(testReponse1.UserName, user.UserName);
            Assert.Equal(testReponse2.UserName, user.UserName);

        }
    }
}
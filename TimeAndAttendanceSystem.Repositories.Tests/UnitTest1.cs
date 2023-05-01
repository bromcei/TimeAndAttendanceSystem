using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using Castle.Core.Logging;
using Moq;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Repositories.Repos.Interfaces;
using TimeAndAttendanceSystem.Repositories.Repositories.Interfaces;
using TimeAndAttendanceSystem.Services.Services;

namespace TimeAndAttendanceSystem.Repositories.Tests
{
    public class UnitTest1
    {
        private readonly Fixture _fixture = new Fixture();
        public UnitTest1()
        {
            _fixture.Customizations.Add(new UserSpecimenBuilder());
        }
        [Theory, CustomDataAttribute]
        public void Test1()
        {
            // Arrange
            var user = _fixture.Create<User>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var userDetailsRepositoryMock = new Mock<IUserDetailsRepository>();
            var userAddressRepositoryMock = new Mock<IUserAddressRepository>();
            var userPhotosRepositoryMock = new Mock<IUserPhotosRepository>();
            var mapperMock = new Mock<IMapper>();
            var sut = new UserService(
                userRepositoryMock.Object, 
                userDetailsRepositoryMock.Object, 
                userAddressRepositoryMock.Object, 
                userPhotosRepositoryMock.Object, 
                mapperMock.Object);
            //var sut = new UnitTest1(userRepositoryMock.Object, mapperMock.Object);
            userRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(user);

            //Act
            var testReponse = sut.GetUserByID(It.IsAny<Guid>()).Result;

            //Assert
            Assert.Equal(testReponse, user);


        }
    }
}
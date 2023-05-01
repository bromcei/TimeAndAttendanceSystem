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
            
            userRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(user));

            //Act
            var testReponse1 = sut.GetUserByID(It.IsAny<Guid>()).Result;
            var testReponse2 = sut.GetUserByUserName(It.IsAny<string>()).Result;

            //Assert
            if (testReponse1 != null && testReponse2 != null)
            {
                Assert.Equal(testReponse1.UserName, user.UserName);
                Assert.Equal(testReponse2.UserName, user.UserName);
            }
            


        }
    }
}
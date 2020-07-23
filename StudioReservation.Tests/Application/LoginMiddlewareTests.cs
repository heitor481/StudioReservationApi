using Moq;
using StudioReservation.Application.Middlewares;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.Entities;
using StudioReservation.Shared.Error;
using StudioReservation.Shared.Resources;
using StudioReservation.Shared.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioReservation.Tests.Application
{
    public class LoginMiddlewareTests
    {
        private readonly ILoginMiddleware stub;
        private readonly Mock<ILoginRepository> loginRepository;
        private readonly Mock<IEnvironmentVariable> environmentVariable;
        private readonly Mock<ISharedResources> sharedResources;
        private readonly Mock<IError> error;

        public LoginMiddlewareTests()
        {
            this.loginRepository = new Mock<ILoginRepository>();
            this.environmentVariable = new Mock<IEnvironmentVariable>();
            this.sharedResources = new Mock<ISharedResources>();
            this.error = new Mock<IError>();
            this.stub = new LoginMiddleware(this.loginRepository.Object, 
                this.environmentVariable.Object, this.error.Object, this.sharedResources.Object);
        }

        [Theory]
        [InlineData("", "Test")]
        [InlineData("Test", "")]
        [InlineData("", "")]
        public async Task Authenticate_Returns_Null_When_Username_Or_Password_Are_Empty(string username, string password) 
        {
            this.environmentVariable.Setup(x => x.GetEnvironmentVariable(It.IsAny<string>())).Returns("test");
            this.error.SetupGet(x => x.Message).Returns(new List<string> 
            {
                "Username is required"
            });

            this.sharedResources.SetupGet(x => x.UsernameRequired).Returns("Username is required");

            var response = await this.stub.Authenticate(username, password);
            Assert.Null(response);
        }

        [Fact]
        public async Task Authenticate_Returns_Null_When_No_User_Is_Found()
        {
            this.environmentVariable.Setup(x => x.GetEnvironmentVariable(It.IsAny<string>())).Returns("test");
            this.error.SetupGet(x => x.Message).Returns(new List<string>
            {
                "We could´t find any user with this usernam and password"
            });

            this.loginRepository.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<Client>(null));

            var response = await this.stub.Authenticate("Test", "Test");
            Assert.Null(response);
        }
    }
}

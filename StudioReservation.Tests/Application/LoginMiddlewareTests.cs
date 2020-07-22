using Moq;
using StudioReservation.Application.Middlewares;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.Shared.Error;
using StudioReservation.Shared.Resources;
using StudioReservation.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;
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

        [Fact]
        public async Task Authenticate_Returns_Null_When_Username_Is_Empty() 
        {
            this.environmentVariable.Setup(x => x.GetEnvironmentVariable(It.IsAny<string>())).Returns("test");
            this.error.SetupGet(x => x.Message).Returns(new List<string> 
            {
                "Username is required"
            });

            this.sharedResources.SetupGet(x => x.UsernameRequired).Returns("Username is required");

            var response = await this.stub.Authenticate("Test", "Test");
            Assert.Null(response);
        }
    }
}

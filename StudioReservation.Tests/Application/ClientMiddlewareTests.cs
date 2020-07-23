using Moq;
using StudioReservation.Application.Middlewares;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.Entities;
using StudioReservation.NewDomain.Enum;
using StudioReservation.NewDomain.ValueObjects;
using StudioReservation.NewDomain.ViewModel;
using StudioReservation.Shared.Error;
using StudioReservation.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioReservation.Tests.Application
{
    public class ClientMiddlewareTests
    {
        private readonly IClientMiddleware stub;
        private readonly Mock<IError> error;
        private readonly Mock<IClientRepository> clientRepository;
        private readonly Mock<ISharedResources> sharedResources;

        public ClientMiddlewareTests()
        {
            this.clientRepository = new Mock<IClientRepository>();
            this.sharedResources = new Mock<ISharedResources>();
            this.error = new Mock<IError>();
            this.stub = new ClientMiddleware(this.clientRepository.Object, this.error.Object, this.sharedResources.Object);
        }

        [Fact]
        public async Task Create_Client_Return_False_If_Firstname_Is_Empty() 
        {
            this.clientRepository.Setup(x => x.CreateClient(It.IsAny<Client>()))
                .Returns(Task.FromResult(false));

            this.error.SetupGet(x => x.Message).Returns(new List<string>
            {
                "Username is required"
            });

            this.sharedResources.SetupGet(x => x.UsernameRequired).Returns("Username is required");

            var createClient = new CreateClientViewModel
            {
                FirstName = "",
                LastName = "Souza",
                Address = new Address("", "", "", "", "", ""),
                Email = new Email("", "", ""),
                Document = new Document("", EDocumentType.CPF),
                DateOfBirth = new DateTime(1993, 02, 02)
            };

            bool response = await this.stub.CreateClient(createClient);
            Assert.False(response);
        }
    }
}

using Moq;
using StudioReservation.Application.Middlewares;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.ValueObjects;
using StudioReservation.NewDomain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioReservation.Tests.Application
{
    public class StudioMiddlewareTests
    {
        private readonly IStudioMiddleware sut;
        private readonly Mock<IStudioRepository> studioRepository;

        public StudioMiddlewareTests()
        {
            this.studioRepository = new Mock<IStudioRepository>();
            this.sut = new StudioMiddleware(this.studioRepository.Object);
        }

        [Fact]
        public async void List_All_Studios_Avaiable()
        {
            var studioViewModelExpected = new List<StudioViewModel>()
            {
                new StudioViewModel
                {
                    Address = new Address("Test","Test","Test","Test","Test","Test"),
                    Id = 1,
                    StudioName = "StudioRock"
                }
            };

            this.studioRepository.Setup(x => x.GetAllStudiosAvailable()).Returns(Task.FromResult<ICollection<StudioViewModel>>(studioViewModelExpected));
            var result = await this.sut.ListAllStudioAvaiable();
            Assert.NotNull(result);
            Assert.Equal(studioViewModelExpected, result);
        }
    }
}

using Moq;
using StudioReservation.Application.Middlewares;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.ValueObjects;
using StudioReservation.NewDomain.ViewModel;
using System.Collections.Generic;
using System.Linq;
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

            //what I'm doing here it's not right, I need to override the method Equals
            var result = await this.sut.ListAllStudioAvaiable();
            Assert.NotNull(result);
            Assert.Equal(result.FirstOrDefault().Id, studioViewModelExpected.FirstOrDefault().Id);
            Assert.Equal(result.FirstOrDefault().StudioName, studioViewModelExpected.FirstOrDefault().StudioName);
            Assert.Equal(result.FirstOrDefault().Address.Country, studioViewModelExpected.FirstOrDefault().Address.Country);
            Assert.Equal(result.FirstOrDefault().Address.City, studioViewModelExpected.FirstOrDefault().Address.City);
            Assert.Equal(result.FirstOrDefault().Address.State, studioViewModelExpected.FirstOrDefault().Address.State);
            Assert.Equal(result.FirstOrDefault().Address.Street, studioViewModelExpected.FirstOrDefault().Address.Street);
            Assert.Equal(result.FirstOrDefault().Address.ZipCode, studioViewModelExpected.FirstOrDefault().Address.ZipCode);
            Assert.Equal(result.FirstOrDefault().Address.Neighborhood, studioViewModelExpected.FirstOrDefault().Address.Neighborhood);
        }
    }
}

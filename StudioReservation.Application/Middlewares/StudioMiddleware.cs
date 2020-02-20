using System.Collections.Generic;
using System.Threading.Tasks;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.Application.Middlewares 
{
    public class StudioMiddleware : IStudioMiddleware
    {
        private readonly IStudioRepository studioRepository;

        public StudioMiddleware(IStudioRepository studioRepository)
        {
            this.studioRepository = studioRepository;
        }

        public async Task<ICollection<Studio>> ListAllStudioAvaiable()
        {
            return await this.studioRepository.GetAllStudiosAvailable();
        }
    }
}
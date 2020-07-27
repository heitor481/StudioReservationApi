using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.Entities;
using StudioReservation.NewDomain.ViewModel;

namespace StudioReservation.Application.Middlewares
{
    public class StudioMiddleware : IStudioMiddleware
    {
        private readonly IStudioRepository studioRepository;

        public StudioMiddleware(IStudioRepository studioRepository)
        {
            this.studioRepository = studioRepository;
        }

        public async Task<ICollection<StudioViewModel>> ListAllStudioAvaiable()
        {
            return await this.studioRepository.GetAllStudiosAvailable();
        }

        public async Task<ICollection<StudioRoom>> ListAllRoomsFromStudio(int studioId)
        {
            var response = await this.studioRepository.ListAllRoomsFromStudio(studioId);

            if (response == null)
            {
                throw new Exception("There's no rooms for that studio");
            }

            return response;
        }
    }
}
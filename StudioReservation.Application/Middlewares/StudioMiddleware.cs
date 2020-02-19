using System.Collections.Generic;
using System.Threading.Tasks;
using StudioReservation.Application.Middlewares.Interfaces;
using StudioReservation.NewData;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.Application.Middlewares 
{
    public class StudioMiddleware : IStudioMiddleware
    {
        private readonly StudioReservationContext dbContext;

        public StudioMiddleware(StudioReservationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<ICollection<Studio>> ListAllStudioAvaiable()
        {
            throw new System.NotImplementedException();
        }
    }
}
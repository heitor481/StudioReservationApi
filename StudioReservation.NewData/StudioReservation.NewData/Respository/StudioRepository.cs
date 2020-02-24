using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Repository 
{
    public class StudioRepository : IStudioRepository
    {
        private readonly StudioReservationContext context;

        public StudioRepository(StudioReservationContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<Studio>> GetAllStudiosAvailable() => await this.context.Studio.ToListAsync();
    }
}
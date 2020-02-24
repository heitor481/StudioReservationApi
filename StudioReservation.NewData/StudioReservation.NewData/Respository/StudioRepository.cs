using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.ViewModel;

namespace StudioReservation.NewData.Repository 
{
    public class StudioRepository : IStudioRepository
    {
        private readonly StudioReservationContext context;

        public StudioRepository(StudioReservationContext context)
        {
            this.context = context;
        }

        
        //This tracking is necessary, because, EF Core 3 will need a tracking when its returning an entire entity not only fields
        //If you just select the fields of the entity, it wont need the AsNoTracking
        //But, I am selecting the entire Address Owned entity
        public async Task<ICollection<StudioViewModel>> GetAllStudiosAvailable() 
        {
            return await this.context.Studio.Include(cp => cp.Address).Select(cp => new StudioViewModel() 
            {
                Id = cp.Id,
                StudioName = cp.StudioName,
                Address = cp.Address

            }).AsNoTracking().ToListAsync();
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Repository 
{
    public class ClientRepository : IClientRepository
    {
        private readonly StudioReservationContext context;
        
        public ClientRepository(StudioReservationContext context)
        {
            this.context = context;
        }

        public async Task<Client> FindClientById(int clientId)
        {
            return await this.context.Client.SingleOrDefaultAsync(options => options.Id == clientId);
        }
    }
}
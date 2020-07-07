using System.Threading.Tasks;
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

        public async Task<bool> CreateClient(Client client)
        {
            this.context.Client.Add(client);
            var success = await this.context.SaveChangesAsync() > 0;
            return success;
        }

        public async Task<Client> FindClientById(int clientId)
        {
            return await this.context.Client.FindAsync(clientId);
        }
    }
}
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly StudioReservationContext context;

        public LoginRepository(StudioReservationContext context)
        {
            this.context = context;
        }

        public async Task<Client> Authenticate(string username, string password)
        {
            return await this.context.Client
            .Include(p => p.Email)
            .SingleOrDefaultAsync(p => p.Email.UserEmail == username && p.Email.Password == password);
        }
    }
}
using System.Threading.Tasks;
using StudioReservation.NewData.Repository.Interfaces;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Repository 
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly StudioReservationContext context;

        public ReservationRepository(StudioReservationContext context)
        {
            this.context = context;
        }

        public Task<Reservation> CreateReservation(Reservation reservation)
        {
            throw new System.NotImplementedException();
        }
    }
}
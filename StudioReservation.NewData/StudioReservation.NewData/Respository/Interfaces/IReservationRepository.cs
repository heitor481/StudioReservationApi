using System.Threading.Tasks;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Repository.Interfaces 
{
    public interface IReservationRepository 
    {
        Task<Reservation> CreateReservation(Reservation reservation);
    }
}
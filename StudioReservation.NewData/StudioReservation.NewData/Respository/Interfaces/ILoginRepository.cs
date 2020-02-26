using System.Threading.Tasks;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Repository.Interfaces 
{ 
    public interface ILoginRepository 
    {
        Task<Client> Authenticate(string username, string password);
    }     
}
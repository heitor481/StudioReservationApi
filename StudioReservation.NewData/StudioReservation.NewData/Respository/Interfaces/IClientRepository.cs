using System.Threading.Tasks;
using StudioReservation.NewDomain.Entities;

namespace StudioReservation.NewData.Repository.Interfaces 
{
    public interface IClientRepository 
    {
        Task<Client> FindClientById(int clientId); 
    }
}